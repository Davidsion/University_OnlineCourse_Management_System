// Controllers/EnrollmentsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrollmentDto>>> GetAllEnrollments()
        {
            var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
            return Ok(enrollments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentDto>> GetEnrollmentById(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpPost]
        public async Task<ActionResult<EnrollmentDto>> CreateEnrollment([FromBody] CreateEnrollmentDto createEnrollmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _enrollmentService.CreateEnrollmentAsync(createEnrollmentDto))
            {
                // Optionally return the created enrollment
                // var createdEnrollment = await _enrollmentService.GetEnrollmentByIdAsync( /* Get ID somehow */ );
                return StatusCode(201); // Created
            }
            else
            {
                return Conflict("Enrollment already exists or invalid Student, Course, or Semester ID.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            if (await _enrollmentService.DeleteEnrollmentAsync(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        // You might not have a typical PUT endpoint for Enrollments due to the unique constraint.
        // If you need to update enrollment details (like EnrollmentDate, if allowed),
        // you would implement a PUT endpoint here.
    }
}