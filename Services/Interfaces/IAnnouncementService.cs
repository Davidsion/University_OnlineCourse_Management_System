// Services/Interfaces/IAnnouncementService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface IAnnouncementService
    {
        Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsAsync();
        Task<AnnouncementDto> GetAnnouncementByIdAsync(int id);
        Task<bool> CreateAnnouncementAsync(CreateAnnouncementDto createAnnouncementDto);
        Task<bool> UpdateAnnouncementAsync(int id, UpdateAnnouncementDto updateAnnouncementDto);
        Task<bool> DeleteAnnouncementAsync(int id);
    }
}
