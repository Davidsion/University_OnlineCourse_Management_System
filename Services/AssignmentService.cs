// Services/AssignmentService.cs
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;

        public AssignmentService(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AssignmentDto>> GetAllAssignmentsAsync()
        {
            var assignments = await _assignmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AssignmentDto>>(assignments);
        }

        public async Task<AssignmentDto> GetAssignmentByIdAsync(int id)
        {
            var assignment = await _assignmentRepository.GetByIdAsync(id);
            return _mapper.Map<AssignmentDto>(assignment);
        }

        public async Task<bool> CreateAssignmentAsync(CreateAssignmentDto createAssignmentDto)
        {
            var assignment = _mapper.Map<Assignment>(createAssignmentDto);
            await _assignmentRepository.AddAsync(assignment);
            return await _assignmentRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateAssignmentAsync(int id, UpdateAssignmentDto updateAssignmentDto)
        {
            var existingAssignment = await _assignmentRepository.GetByIdAsync(id);
            if (existingAssignment == null)
            {
                return false;
            }

            _mapper.Map(updateAssignmentDto, existingAssignment);
            _assignmentRepository.Update(existingAssignment);
            return await _assignmentRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            var assignmentToDelete = await _assignmentRepository.GetByIdAsync(id);
            if (assignmentToDelete == null)
            {
                return false;
            }

            _assignmentRepository.Delete(assignmentToDelete);
            return await _assignmentRepository.SaveChangesAsync();
        }
    }
}
