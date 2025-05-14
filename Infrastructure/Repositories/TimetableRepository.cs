// Infrastructure/Repositories/TimetableRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class TimetableRepository : ITimetableRepository
    {
        private readonly UniversityDbContext _dbContext;

        public TimetableRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Timetable>> GetAllAsync()
        {
            return await _dbContext.Timetables.ToListAsync();
        }

        public async Task<Timetable> GetByIdAsync(int id)
        {
            return await _dbContext.Timetables.FindAsync(id);
        }

        public async Task AddAsync(Timetable timetable)
        {
            await _dbContext.Timetables.AddAsync(timetable);
        }

        public void Update(Timetable timetable)
        {
            _dbContext.Entry(timetable).State = EntityState.Modified;
        }

        public void Delete(Timetable timetable)
        {
            _dbContext.Timetables.Remove(timetable);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
