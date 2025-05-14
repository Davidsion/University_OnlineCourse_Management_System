// Infrastructure/Repositories/AnnouncementRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly UniversityDbContext _dbContext;

        public AnnouncementRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Announcement>> GetAllAsync()
        {
            return await _dbContext.Announcements.ToListAsync();
        }

        public async Task<Announcement> GetByIdAsync(int id)
        {
            return await _dbContext.Announcements.FindAsync(id);
        }

        public async Task AddAsync(Announcement announcement)
        {
            await _dbContext.Announcements.AddAsync(announcement);
        }

        public void Update(Announcement announcement)
        {
            _dbContext.Entry(announcement).State = EntityState.Modified;
        }

        public void Delete(Announcement announcement)
        {
            _dbContext.Announcements.Remove(announcement);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}