// Services/DepartmentService.cs
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(string id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<bool> CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto)
        {
            if (await _departmentRepository.GetByIdAsync(createDepartmentDto.DepartmentID) != null)
            {
                return false; // Department ID already exists
            }

            var department = _mapper.Map<Department>(createDepartmentDto);
            await _departmentRepository.AddAsync(department);
            return await _departmentRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateDepartmentAsync(string id, UpdateDepartmentDto updateDepartmentDto)
        {
            var existingDepartment = await _departmentRepository.GetByIdAsync(id);
            if (existingDepartment == null)
            {
                return false;
            }

            _mapper.Map(updateDepartmentDto, existingDepartment);
            _departmentRepository.Update(existingDepartment);
            return await _departmentRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteDepartmentAsync(string id)
        {
            var departmentToDelete = await _departmentRepository.GetByIdAsync(id);
            if (departmentToDelete == null)
            {
                return false;
            }

            _departmentRepository.Delete(departmentToDelete);
            return await _departmentRepository.SaveChangesAsync();
        }
    }
}