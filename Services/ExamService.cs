// Services/ExamService.cs
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public ExamService(IExamRepository examRepository, IMapper mapper)
        {
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExamDto>> GetAllExamsAsync()
        {
            var exams = await _examRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ExamDto>>(exams);
        }

        public async Task<ExamDto> GetExamByIdAsync(int id)
        {
            var exam = await _examRepository.GetByIdAsync(id);
            return _mapper.Map<ExamDto>(exam);
        }

        public async Task<bool> CreateExamAsync(CreateExamDto createExamDto)
        {
            var exam = _mapper.Map<Exam>(createExamDto);
            await _examRepository.AddAsync(exam);
            return await _examRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateExamAsync(int id, UpdateExamDto updateExamDto)
        {
            var existingExam = await _examRepository.GetByIdAsync(id);
            if (existingExam == null)
            {
                return false;
            }

            _mapper.Map(updateExamDto, existingExam);
            _examRepository.Update(existingExam);
            return await _examRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteExamAsync(int id)
        {
            var examToDelete = await _examRepository.GetByIdAsync(id);
            if (examToDelete == null)
            {
                return false;
            }

            _examRepository.Delete(examToDelete);
            return await _examRepository.SaveChangesAsync();
        }
    }
}
