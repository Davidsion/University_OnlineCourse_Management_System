// Infrastructure/Repositories/SubmissionRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly UniversityDbContext _dbContext;

        public SubmissionRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Submission>> GetAllAsync()
        {
            return await _dbContext.Submissions.ToListAsync();
        }

        public async Task<Submission> GetByIdAsync(int id)
        {
            return await _dbContext.Submissions.FindAsync(id);
        }

        public async Task AddAsync(Submission submission)
        {
            await _dbContext.Submissions.AddAsync(submission);
        }

        public void Update(Submission submission)
        {
            _dbContext.Entry(submission).State = EntityState.Modified;
        }

        public void Delete(Submission submission)
        {
            _dbContext.Submissions.Remove(submission);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
