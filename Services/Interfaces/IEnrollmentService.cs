// Services/Interfaces/IEnrollmentService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<EnrollmentDto>> GetAllEnrollmentsAsync();
        Task<EnrollmentDto> GetEnrollmentByIdAsync(int id);
        Task<bool> CreateEnrollmentAsync(CreateEnrollmentDto createEnrollmentDto);
        Task<bool> DeleteEnrollmentAsync(int id);
        // You might not have a typical Update for Enrollments based on the unique constraint.
        // If you need to update enrollment details (like EnrollmentDate, if allowed),
        // you would define an UpdateEnrollmentDto and the corresponding service method.
    }
}