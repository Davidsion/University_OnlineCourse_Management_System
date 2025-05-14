// Infrastructure/Repositories/ISemesterRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface ISemesterRepository
    {
        Task<IEnumerable<Semester>> GetAllAsync();
        Task<Semester> GetByIdAsync(string id);
        Task AddAsync(Semester semester);
        void Update(Semester semester);
        void Delete(Semester semester);
        Task<bool> SaveChangesAsync();
    }
}