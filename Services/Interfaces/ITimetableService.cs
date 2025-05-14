// Services/Interfaces/ITimetableService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface ITimetableService
    {
        Task<IEnumerable<TimetableDto>> GetAllTimetablesAsync();
        Task<TimetableDto> GetTimetableByIdAsync(int id);
        Task<bool> CreateTimetableAsync(CreateTimetableDto createTimetableDto);
        Task<bool> UpdateTimetableAsync(int id, UpdateTimetableDto updateTimetableDto);
        Task<bool> DeleteTimetableAsync(int id);
    }
}

