// Services/InstructorService.cs
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IDepartmentRepository _departmentRepository; // To validate DepartmentID
        private readonly IMapper _mapper;

        public InstructorService(IInstructorRepository instructorRepository, IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstructorDto>> GetAllInstructorsAsync()
        {
            var instructors = await _instructorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<InstructorDto>>(instructors);
        }

        public async Task<InstructorDto> GetInstructorByIdAsync(string id)
        {
            var instructor = await _instructorRepository.GetByIdAsync(id);
            return _mapper.Map<InstructorDto>(instructor);
        }

        public async Task<InstructorDto> GetInstructorByEmailAsync(string email)
        {
            var instructor = await _instructorRepository.GetByEmailAsync(email);
            return _mapper.Map<InstructorDto>(instructor);
        }

        public async Task<bool> CreateInstructorAsync(CreateInstructorDto createInstructorDto)
        {
            // Check if InstructorID already exists
            if (await _instructorRepository.GetByIdAsync(createInstructorDto.InstructorID) != null)
            {
                return false; // Instructor ID already exists
            }

            // Check if Email already exists
            if (await _instructorRepository.GetByEmailAsync(createInstructorDto.Email) != null)
            {
                return false; // Email already exists
            }

            // Validate DepartmentID
            var departmentExists = await _departmentRepository.GetByIdAsync(createInstructorDto.DepartmentID);
            if (departmentExists == null)
            {
                return false; // Invalid DepartmentID
            }

            var instructor = _mapper.Map<Instructor>(createInstructorDto);
            await _instructorRepository.AddAsync(instructor);
            return await _instructorRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateInstructorAsync(string id, UpdateInstructorDto updateInstructorDto)
        {
            var existingInstructor = await _instructorRepository.GetByIdAsync(id);
            if (existingInstructor == null)
            {
                return false; // Instructor not found
            }

            // Check if the new email is different and already exists
            if (updateInstructorDto.Email != null && updateInstructorDto.Email != existingInstructor.Email && await _instructorRepository.GetByEmailAsync(updateInstructorDto.Email) != null)
            {
                return false; // New email already exists
            }

            // Validate DepartmentID if it's being updated
            if (updateInstructorDto.DepartmentID != null)
            {
                var departmentExists = await _departmentRepository.GetByIdAsync(updateInstructorDto.DepartmentID);
                if (departmentExists == null)
                {
                    return false; // Invalid DepartmentID
                }
            }

            _mapper.Map(updateInstructorDto, existingInstructor);
            _instructorRepository.Update(existingInstructor);
            return await _instructorRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteInstructorAsync(string id)
        {
            var instructorToDelete = await _instructorRepository.GetByIdAsync(id);
            if (instructorToDelete == null)
            {
                return false; // Instructor not found
            }

            _instructorRepository.Delete(instructorToDelete);
            return await _instructorRepository.SaveChangesAsync();
        }
    }
}