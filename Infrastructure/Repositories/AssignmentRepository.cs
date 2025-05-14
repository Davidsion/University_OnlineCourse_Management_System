// Infrastructure/Repositories/AssignmentRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly UniversityDbContext _dbContext;

        public AssignmentRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Assignment>> GetAllAsync()
        {
            return await _dbContext.Assignments.ToListAsync();
        }

        public async Task<Assignment> GetByIdAsync(int id)
        {
            return await _dbContext.Assignments.FindAsync(id);
        }

        public async Task AddAsync(Assignment assignment)
        {
            await _dbContext.Assignments.AddAsync(assignment);
        }

        public void Update(Assignment assignment)
        {
            _dbContext.Entry(assignment).State = EntityState.Modified;
        }

        public void Delete(Assignment assignment)
        {
            _dbContext.Assignments.Remove(assignment);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
