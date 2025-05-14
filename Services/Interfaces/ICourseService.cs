// Services/Interfaces/ICourseService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync();
        Task<CourseDto> GetCourseByIdAsync(string id);
        Task<CourseDto> GetCourseByCodeAsync(string courseCode);
        Task<bool> CreateCourseAsync(CreateCourseDto createCourseDto);
        Task<bool> UpdateCourseAsync(string id, UpdateCourseDto updateCourseDto);
        Task<bool> DeleteCourseAsync(string id);
    }
}
