// Infrastructure/Repositories/ICourseRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(string id);
        Task<Course> GetByCourseCodeAsync(string courseCode);
        Task AddAsync(Course course);
        void Update(Course course);
        void Delete(Course course);
        Task<bool> SaveChangesAsync();
    }
}
