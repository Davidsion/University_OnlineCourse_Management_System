// Infrastructure/Repositories/IInstructorRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface IInstructorRepository
    {
        Task<IEnumerable<Instructor>> GetAllAsync();
        Task<Instructor> GetByIdAsync(string id);
        Task<Instructor> GetByEmailAsync(string email); // Added for unique email check
        Task AddAsync(Instructor instructor);
        void Update(Instructor instructor);
        void Delete(Instructor instructor);
        Task<bool> SaveChangesAsync();
    }
}