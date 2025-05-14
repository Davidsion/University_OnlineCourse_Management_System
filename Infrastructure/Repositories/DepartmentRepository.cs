// Infrastructure/Repositories/DepartmentRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly UniversityDbContext _dbContext;

        public DepartmentRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public async Task<Department> GetByIdAsync(string id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }

        public async Task AddAsync(Department department)
        {
            await _dbContext.Departments.AddAsync(department);
        }

        public void Update(Department department)
        {
            _dbContext.Entry(department).State = EntityState.Modified;
        }

        public void Delete(Department department)
        {
            _dbContext.Departments.Remove(department);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}