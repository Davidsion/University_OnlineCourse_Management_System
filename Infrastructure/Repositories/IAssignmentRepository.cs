// Infrastructure/Repositories/IAssignmentRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> GetAllAsync();
        Task<Assignment> GetByIdAsync(int id);
        Task AddAsync(Assignment assignment);
        void Update(Assignment assignment);
        void Delete(Assignment assignment);
        Task<bool> SaveChangesAsync();
    }
}
