using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface ILibraryResourceService
    {
        Task<IEnumerable<LibraryResourceDto>> GetAllLibraryResourcesAsync();
        Task<LibraryResourceDto> GetLibraryResourceByIdAsync(int id);
        Task<bool> CreateLibraryResourceAsync(CreateLibraryResourceDto createLibraryResourceDto);
        Task<bool> UpdateLibraryResourceAsync(int id, UpdateLibraryResourceDto updateLibraryResourceDto);
        Task<bool> DeleteLibraryResourceAsync(int id);
    }
}