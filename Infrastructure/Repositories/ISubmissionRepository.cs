// Infrastructure/Repositories/ISubmissionRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface ISubmissionRepository
    {
        Task<IEnumerable<Submission>> GetAllAsync();
        Task<Submission> GetByIdAsync(int id);
        Task AddAsync(Submission submission);
        void Update(Submission submission);
        void Delete(Submission submission);
        Task<bool> SaveChangesAsync();
    }
}

