// Infrastructure/Repositories/IAnnouncementRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> GetAllAsync();
        Task<Announcement> GetByIdAsync(int id);
        Task AddAsync(Announcement announcement);
        void Update(Announcement announcement);
        void Delete(Announcement announcement);
        Task<bool> SaveChangesAsync();
    }
}
