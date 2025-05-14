// Infrastructure/Repositories/IStudentRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(string id);
        Task<Student> GetByEmailAsync(string email); // Added for unique email check
        Task AddAsync(Student student);
        void Update(Student student);
        void Delete(Student student);
        Task<bool> SaveChangesAsync();
    }
}