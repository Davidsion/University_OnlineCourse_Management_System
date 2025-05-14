// Infrastructure/Repositories/IDepartmentRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(string id);
        Task AddAsync(Department department);
        void Update(Department department);
        void Delete(Department department);
        Task<bool> SaveChangesAsync();
    }
}
