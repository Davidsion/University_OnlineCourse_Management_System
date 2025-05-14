// Infrastructure/Repositories/EnrollmentRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly UniversityDbContext _dbContext;

        public EnrollmentRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            return await _dbContext.Enrollments
                                 .Include(e => e.Student)
                                 .Include(e => e.Course)
                                 .Include(e => e.Semester)
                                 .ToListAsync();
        }

        public async Task<Enrollment> GetByIdAsync(int id)
        {
            return await _dbContext.Enrollments
                                 .Include(e => e.Student)
                                 .Include(e => e.Course)
                                 .Include(e => e.Semester)
                                 .FirstOrDefaultAsync(e => e.EnrollmentID == id);
        }

        public async Task<Enrollment> GetByStudentCourseSemesterAsync(string studentId, string courseId, string semesterId)
        {
            return await _dbContext.Enrollments
                                 .FirstOrDefaultAsync(e => e.StudentID == studentId &&
                                                          e.CourseID == courseId &&
                                                          e.SemesterID == semesterId);
        }

        public async Task AddAsync(Enrollment enrollment)
        {
            await _dbContext.Enrollments.AddAsync(enrollment);
        }

        public void Update(Enrollment enrollment)
        {
            _dbContext.Entry(enrollment).State = EntityState.Modified;
        }

        public void Delete(Enrollment enrollment)
        {
            _dbContext.Enrollments.Remove(enrollment);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}