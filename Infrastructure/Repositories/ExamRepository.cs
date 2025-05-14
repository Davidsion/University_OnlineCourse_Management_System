// Infrastructure/Repositories/ExamRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly UniversityDbContext _dbContext;

        public ExamRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await _dbContext.Exams.ToListAsync();
        }

        public async Task<Exam> GetByIdAsync(int id)
        {
            return await _dbContext.Exams.FindAsync(id);
        }

        public async Task AddAsync(Exam exam)
        {
            await _dbContext.Exams.AddAsync(exam);
        }

        public void Update(Exam exam)
        {
            _dbContext.Entry(exam).State = EntityState.Modified;
        }

        public void Delete(Exam exam)
        {
            _dbContext.Exams.Remove(exam);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
