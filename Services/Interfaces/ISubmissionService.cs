// Services/Interfaces/ISubmissionService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface ISubmissionService
    {
        Task<IEnumerable<SubmissionDto>> GetAllSubmissionsAsync();
        Task<SubmissionDto> GetSubmissionByIdAsync(int id);
        Task<bool> CreateSubmissionAsync(CreateSubmissionDto createSubmissionDto);
        Task<bool> UpdateSubmissionAsync(int id, UpdateSubmissionDto updateSubmissionDto);
        Task<bool> DeleteSubmissionAsync(int id);
    }
}

