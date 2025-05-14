// Infrastructure/Repositories/StudentRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UniversityDbContext _dbContext;

        public StudentRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _dbContext.Students.Include(s => s.Department).ToListAsync(); // Include related Department
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await _dbContext.Students.Include(s => s.Department).FirstOrDefaultAsync(s => s.StudentID == id); // Include related Department
        }

        public async Task<Student> GetByEmailAsync(string email)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task AddAsync(Student student)
        {
            await _dbContext.Students.AddAsync(student);
        }

        public void Update(Student student)
        {
            _dbContext.Entry(student).State = EntityState.Modified;
        }

        public void Delete(Student student)
        {
            _dbContext.Students.Remove(student);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}