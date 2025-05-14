using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface ILibraryResourceRepository
    {
        Task<IEnumerable<LibraryResource>> GetAllAsync();
        Task<LibraryResource> GetByIdAsync(int id);
        Task AddAsync(LibraryResource libraryResource);
        void Update(LibraryResource libraryResource);
        void Delete(LibraryResource libraryResource);
        Task<bool> SaveChangesAsync();
    }
}