// Services/SemesterService.cs
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _semesterRepository;
        private readonly IMapper _mapper;

        public SemesterService(ISemesterRepository semesterRepository, IMapper mapper)
        {
            _semesterRepository = semesterRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SemesterDto>> GetAllSemestersAsync()
        {
            var semesters = await _semesterRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SemesterDto>>(semesters);
        }

        public async Task<SemesterDto> GetSemesterByIdAsync(string id)
        {
            var semester = await _semesterRepository.GetByIdAsync(id);
            return _mapper.Map<SemesterDto>(semester);
        }

        public async Task<bool> CreateSemesterAsync(CreateSemesterDto createSemesterDto)
        {
            if (await _semesterRepository.GetByIdAsync(createSemesterDto.SemesterID) != null)
            {
                return false; // Semester ID already exists
            }

            var semester = _mapper.Map<Semester>(createSemesterDto);
            await _semesterRepository.AddAsync(semester);
            return await _semesterRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateSemesterAsync(string id, UpdateSemesterDto updateSemesterDto)
        {
            var existingSemester = await _semesterRepository.GetByIdAsync(id);
            if (existingSemester == null)
            {
                return false;
            }

            _mapper.Map(updateSemesterDto, existingSemester);
            _semesterRepository.Update(existingSemester);
            return await _semesterRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteSemesterAsync(string id)
        {
            var semesterToDelete = await _semesterRepository.GetByIdAsync(id);
            if (semesterToDelete == null)
            {
                return false;
            }

            _semesterRepository.Delete(semesterToDelete);
            return await _semesterRepository.SaveChangesAsync();
        }
    }
}