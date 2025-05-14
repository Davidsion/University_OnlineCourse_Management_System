// Services/Interfaces/IAttendanceService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDto>> GetAllAttendancesAsync();
        Task<AttendanceDto> GetAttendanceByIdAsync(int id);
        Task<IEnumerable<AttendanceDto>> GetAttendanceByEnrollmentAndDateAsync(int enrollmentId, DateTime date);
        Task<bool> MarkAttendanceAsync(CreateAttendanceDto createAttendanceDto);
        Task<bool> UpdateAttendanceAsync(int id, UpdateAttendanceDto updateAttendanceDto);
        Task<bool> DeleteAttendanceAsync(int id);
    }
}

