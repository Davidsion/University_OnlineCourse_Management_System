// Controllers/AttendancesController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendancesController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceDto>>> GetAllAttendances()
        {
            var attendances = await _attendanceService.GetAllAttendancesAsync();
            return Ok(attendances);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceDto>> GetAttendanceById(int id)
        {
            var attendance = await _attendanceService.GetAttendanceByIdAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }

        [HttpGet("enrollment/{enrollmentId}/date/{date}")]
        public async Task<ActionResult<IEnumerable<AttendanceDto>>> GetAttendanceByEnrollmentAndDate(int enrollmentId, DateTime date)
        {
            var attendances = await _attendanceService.GetAttendanceByEnrollmentAndDateAsync(enrollmentId, date);
            return Ok(attendances);
        }

        [HttpPost]
        public async Task<ActionResult<AttendanceDto>> MarkAttendance([FromBody] CreateAttendanceDto createAttendanceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _attendanceService.MarkAttendanceAsync(createAttendanceDto))
            {
                var createdAttendance = await _attendanceService.GetAttendanceByEnrollmentAndDateAsync(createAttendanceDto.EnrollmentID, createAttendanceDto.Date);
                return CreatedAtAction(nameof(GetAttendanceByEnrollmentAndDate), new { enrollmentId = createAttendanceDto.EnrollmentID, date = createAttendanceDto.Date.ToString("yyyy-MM-dd") }, createdAttendance.FirstOrDefault());
            }
            else
            {
                return Conflict("Attendance for this enrollment and date already marked.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(int id, [FromBody] UpdateAttendanceDto updateAttendanceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _attendanceService.UpdateAttendanceAsync(id, updateAttendanceDto))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            if (await _attendanceService.DeleteAttendanceAsync(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}