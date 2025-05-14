// Services/GradeService.cs
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public GradeService(IGradeRepository gradeRepository, IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GradeDto>> GetAllGradesAsync()
        {
            var grades = await _gradeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GradeDto>>(grades);
        }

        public async Task<GradeDto> GetGradeByIdAsync(int id)
        {
            var grade = await _gradeRepository.GetByIdAsync(id);
            return _mapper.Map<GradeDto>(grade);
        }

        public async Task<bool> CreateGradeAsync(CreateGradeDto createGradeDto)
        {
            var grade = _mapper.Map<Grade>(createGradeDto);
            await _gradeRepository.AddAsync(grade);
            return await _gradeRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateGradeAsync(int id, UpdateGradeDto updateGradeDto)
        {
            var existingGrade = await _gradeRepository.GetByIdAsync(id);
            if (existingGrade == null)
            {
                return false;
            }

            _mapper.Map(updateGradeDto, existingGrade);
            _gradeRepository.Update(existingGrade);
            return await _gradeRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteGradeAsync(int id)
        {
            var gradeToDelete = await _gradeRepository.GetByIdAsync(id);
            if (gradeToDelete == null)
            {
                return false;
            }

            _gradeRepository.Delete(gradeToDelete);
            return await _gradeRepository.SaveChangesAsync();
        }
    }
}
