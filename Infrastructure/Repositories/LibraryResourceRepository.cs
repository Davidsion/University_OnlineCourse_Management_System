using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class LibraryResourceRepository : ILibraryResourceRepository
    {
        private readonly UniversityDbContext _dbContext;

        public LibraryResourceRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LibraryResource>> GetAllAsync()
        {
            return await _dbContext.LibraryResources.ToListAsync();
        }

        public async Task<LibraryResource> GetByIdAsync(int id)
        {
            return await _dbContext.LibraryResources.FindAsync(id);
        }

        public async Task AddAsync(LibraryResource libraryResource)
        {
            await _dbContext.LibraryResources.AddAsync(libraryResource);
        }

        public void Update(LibraryResource libraryResource)
        {
            _dbContext.Entry(libraryResource).State = EntityState.Modified;
        }

        public void Delete(LibraryResource libraryResource)
        {
            _dbContext.LibraryResources.Remove(libraryResource);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}