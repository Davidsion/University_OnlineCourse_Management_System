// Infrastructure/Repositories/SemesterRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly UniversityDbContext _dbContext;

        public SemesterRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Semester>> GetAllAsync()
        {
            return await _dbContext.Semesters.ToListAsync();
        }

        public async Task<Semester> GetByIdAsync(string id)
        {
            return await _dbContext.Semesters.FindAsync(id);
        }

        public async Task AddAsync(Semester semester)
        {
            await _dbContext.Semesters.AddAsync(semester);
        }

        public void Update(Semester semester)
        {
            _dbContext.Entry(semester).State = EntityState.Modified;
        }

        public void Delete(Semester semester)
        {
            _dbContext.Semesters.Remove(semester);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
