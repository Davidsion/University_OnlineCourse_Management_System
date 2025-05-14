// Services/Interfaces/IAssignmentService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface IAssignmentService
    {
        Task<IEnumerable<AssignmentDto>> GetAllAssignmentsAsync();
        Task<AssignmentDto> GetAssignmentByIdAsync(int id);
        Task<bool> CreateAssignmentAsync(CreateAssignmentDto createAssignmentDto);
        Task<bool> UpdateAssignmentAsync(int id, UpdateAssignmentDto updateAssignmentDto);
        Task<bool> DeleteAssignmentAsync(int id);
    }
}
