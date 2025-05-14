// Services/Interfaces/ISemesterService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface ISemesterService
    {
        Task<IEnumerable<SemesterDto>> GetAllSemestersAsync();
        Task<SemesterDto> GetSemesterByIdAsync(string id);
        Task<bool> CreateSemesterAsync(CreateSemesterDto createSemesterDto);
        Task<bool> UpdateSemesterAsync(string id, UpdateSemesterDto updateSemesterDto);
        Task<bool> DeleteSemesterAsync(string id);
    }
}