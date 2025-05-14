// Infrastructure/Repositories/InstructorRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly UniversityDbContext _dbContext;

        public InstructorRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            return await _dbContext.Instructors.Include(i => i.Department).ToListAsync(); // Include related Department
        }

        public async Task<Instructor> GetByIdAsync(string id)
        {
            return await _dbContext.Instructors.Include(i => i.Department).FirstOrDefaultAsync(i => i.InstructorID == id); // Include related Department
        }

        public async Task<Instructor> GetByEmailAsync(string email)
        {
            return await _dbContext.Instructors.FirstOrDefaultAsync(i => i.Email == email);
        }

        public async Task AddAsync(Instructor instructor)
        {
            await _dbContext.Instructors.AddAsync(instructor);
        }

        public void Update(Instructor instructor)
        {
            _dbContext.Entry(instructor).State = EntityState.Modified;
        }

        public void Delete(Instructor instructor)
        {
            _dbContext.Instructors.Remove(instructor);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}