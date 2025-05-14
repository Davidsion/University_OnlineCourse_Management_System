// Infrastructure/Repositories/CourseRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityDbContext _dbContext;

        public CourseRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _dbContext.Courses.Include(c => c.Department).ToListAsync(); // Include related Department
        }

        public async Task<Course> GetByIdAsync(string id)
        {
            return await _dbContext.Courses.Include(c => c.Department).FirstOrDefaultAsync(c => c.CourseID == id); // Include related Department
        }

        public async Task<Course> GetByCourseCodeAsync(string courseCode)
        {
            return await _dbContext.Courses.FirstOrDefaultAsync(c => c.CourseCode == courseCode);
        }

        public async Task AddAsync(Course course)
        {
            await _dbContext.Courses.AddAsync(course);
        }

        public void Update(Course course)
        {
            _dbContext.Entry(course).State = EntityState.Modified;
        }

        public void Delete(Course course)
        {
            _dbContext.Courses.Remove(course);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
