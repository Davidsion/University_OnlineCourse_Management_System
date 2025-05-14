// Infrastructure/Repositories/GradeRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly UniversityDbContext _dbContext;

        public GradeRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Grade>> GetAllAsync()
        {
            return await _dbContext.Grades.ToListAsync();
        }

        public async Task<Grade> GetByIdAsync(int id)
        {
            return await _dbContext.Grades.FindAsync(id);
        }

        public async Task AddAsync(Grade grade)
        {
            await _dbContext.Grades.AddAsync(grade);
        }

        public void Update(Grade grade)
        {
            _dbContext.Entry(grade).State = EntityState.Modified;
        }

        public void Delete(Grade grade)
        {
            _dbContext.Grades.Remove(grade);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
