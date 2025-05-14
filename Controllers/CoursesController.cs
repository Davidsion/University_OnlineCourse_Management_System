// Controllers/CoursesController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourseById(string id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpGet("code/{courseCode}")]
        public async Task<ActionResult<CourseDto>> GetCourseByCode(string courseCode)
        {
            var course = await _courseService.GetCourseByCodeAsync(courseCode);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> CreateCourse([FromBody] CreateCourseDto createCourseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _courseService.CreateCourseAsync(createCourseDto))
            {
                var createdCourse = await _courseService.GetCourseByIdAsync(createCourseDto.CourseID);
                return CreatedAtAction(nameof(GetCourseById), new { id = createdCourse.CourseID }, createdCourse);
            }
            else
            {
                return Conflict("Course ID or Course Code already exists, or invalid Department ID.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(string id, [FromBody] UpdateCourseDto updateCourseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _courseService.UpdateCourseAsync(id, updateCourseDto))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            if (await _courseService.DeleteCourseAsync(id))
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
