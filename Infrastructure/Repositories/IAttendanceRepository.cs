// Infrastructure/Repositories/IAttendanceRepository.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllAsync();
        Task<Attendance> GetByIdAsync(int id);
        Task<IEnumerable<Attendance>> GetByEnrollmentAndDateAsync(int enrollmentId, DateTime date);
        Task AddAsync(Attendance attendance);
        void Update(Attendance attendance);
        void Delete(Attendance attendance);
        Task<bool> SaveChangesAsync();
    }
}

