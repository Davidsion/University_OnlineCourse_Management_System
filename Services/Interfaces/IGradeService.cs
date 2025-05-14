// Services/Interfaces/IGradeService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface IGradeService
    {
        Task<IEnumerable<GradeDto>> GetAllGradesAsync();
        Task<GradeDto> GetGradeByIdAsync(int id);
        Task<bool> CreateGradeAsync(CreateGradeDto createGradeDto);
        Task<bool> UpdateGradeAsync(int id, UpdateGradeDto updateGradeDto);
        Task<bool> DeleteGradeAsync(int id);
    }
}
