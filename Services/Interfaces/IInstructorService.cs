// Services/Interfaces/IInstructorService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface IInstructorService
    {
        Task<IEnumerable<InstructorDto>> GetAllInstructorsAsync();
        Task<InstructorDto> GetInstructorByIdAsync(string id);
        Task<InstructorDto> GetInstructorByEmailAsync(string email);
        Task<bool> CreateInstructorAsync(CreateInstructorDto createInstructorDto);
        Task<bool> UpdateInstructorAsync(string id, UpdateInstructorDto updateInstructorDto);
        Task<bool> DeleteInstructorAsync(string id);
    }
}