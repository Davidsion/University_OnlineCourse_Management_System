// Services/Interfaces/IStudentService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> GetStudentByIdAsync(string id);
        Task<StudentDto> GetStudentByEmailAsync(string email);
        Task<bool> CreateStudentAsync(CreateStudentDto createStudentDto);
        Task<bool> UpdateStudentAsync(string id, UpdateStudentDto updateStudentDto);
        Task<bool> DeleteStudentAsync(string id);
    }
}