// Services/SubmissionService.cs
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IMapper _mapper;

        public SubmissionService(ISubmissionRepository submissionRepository, IMapper mapper)
        {
            _submissionRepository = submissionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubmissionDto>> GetAllSubmissionsAsync()
        {
            var submissions = await _submissionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubmissionDto>>(submissions);
        }

        public async Task<SubmissionDto> GetSubmissionByIdAsync(int id)
        {
            var submission = await _submissionRepository.GetByIdAsync(id);
            return _mapper.Map<SubmissionDto>(submission);
        }

        public async Task<bool> CreateSubmissionAsync(CreateSubmissionDto createSubmissionDto)
        {
            var submission = _mapper.Map<Submission>(createSubmissionDto);
            // The SubmissionDate will be handled by the database default.
            await _submissionRepository.AddAsync(submission);
            return await _submissionRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateSubmissionAsync(int id, UpdateSubmissionDto updateSubmissionDto)
        {
            var existingSubmission = await _submissionRepository.GetByIdAsync(id);
            if (existingSubmission == null)
            {
                return false;
            }

            _mapper.Map(updateSubmissionDto, existingSubmission);
            _submissionRepository.Update(existingSubmission);
            return await _submissionRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteSubmissionAsync(int id)
        {
            var submissionToDelete = await _submissionRepository.GetByIdAsync(id);
            if (submissionToDelete == null)
            {
                return false;
            }

            _submissionRepository.Delete(submissionToDelete);
            return await _submissionRepository.SaveChangesAsync();
        }
    }
}
