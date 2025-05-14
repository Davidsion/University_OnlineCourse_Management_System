// Services/Interfaces/IExamService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface IExamService
    {
        Task<IEnumerable<ExamDto>> GetAllExamsAsync();
        Task<ExamDto> GetExamByIdAsync(int id);
        Task<bool> CreateExamAsync(CreateExamDto createExamDto);
        Task<bool> UpdateExamAsync(int id, UpdateExamDto updateExamDto);
        Task<bool> DeleteExamAsync(int id);
    }
}
