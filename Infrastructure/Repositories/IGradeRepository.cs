// Infrastructure/Repositories/IGradeRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetAllAsync();
        Task<Grade> GetByIdAsync(int id);
        Task AddAsync(Grade grade);
        void Update(Grade grade);
        void Delete(Grade grade);
        Task<bool> SaveChangesAsync();
    }
}
