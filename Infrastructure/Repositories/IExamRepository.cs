// Infrastructure/Repositories/IExamRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetAllAsync();
        Task<Exam> GetByIdAsync(int id);
        Task AddAsync(Exam exam);
        void Update(Exam exam);
        void Delete(Exam exam);
        Task<bool> SaveChangesAsync();
    }
}
