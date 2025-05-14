// Infrastructure/Repositories/IEnrollmentRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetAllAsync();
        Task<Enrollment> GetByIdAsync(int id);
        Task<Enrollment> GetByStudentCourseSemesterAsync(string studentId, string courseId, string semesterId); // For checking uniqueness
        Task AddAsync(Enrollment enrollment);
        void Update(Enrollment enrollment);
        void Delete(Enrollment enrollment);
        Task<bool> SaveChangesAsync();
    }
}