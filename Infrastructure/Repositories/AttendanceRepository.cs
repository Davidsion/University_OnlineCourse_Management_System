// Infrastructure/Repositories/AttendanceRepository.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly UniversityDbContext _dbContext;

        public AttendanceRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _dbContext.Attendances.ToListAsync();
        }

        public async Task<Attendance> GetByIdAsync(int id)
        {
            return await _dbContext.Attendances.FindAsync(id);
        }

        public async Task<IEnumerable<Attendance>> GetByEnrollmentAndDateAsync(int enrollmentId, DateTime date)
        {
            return await _dbContext.Attendances
                .Where(a => a.EnrollmentID == enrollmentId && a.Date.Date == date.Date)
                .ToListAsync();
        }

        public async Task AddAsync(Attendance attendance)
        {
            await _dbContext.Attendances.AddAsync(attendance);
        }

        public void Update(Attendance attendance)
        {
            _dbContext.Entry(attendance).State = EntityState.Modified;
        }

        public void Delete(Attendance attendance)
        {
            _dbContext.Attendances.Remove(attendance);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
