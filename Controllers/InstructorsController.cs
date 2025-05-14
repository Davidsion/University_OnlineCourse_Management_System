// Controllers/InstructorsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorDto>>> GetAllInstructors()
        {
            var instructors = await _instructorService.GetAllInstructorsAsync();
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorDto>> GetInstructorById(string id)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return Ok(instructor);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<InstructorDto>> GetInstructorByEmail(string email)
        {
            var instructor = await _instructorService.GetInstructorByEmailAsync(email);
            if (instructor == null)
            {
                return NotFound();
            }
            return Ok(instructor);
        }

        [HttpPost]
        public async Task<ActionResult<InstructorDto>> CreateInstructor([FromBody] CreateInstructorDto createInstructorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _instructorService.CreateInstructorAsync(createInstructorDto))
            {
                var createdInstructor = await _instructorService.GetInstructorByIdAsync(createInstructorDto.InstructorID);
                return CreatedAtAction(nameof(GetInstructorById), new { id = createdInstructor.InstructorID }, createdInstructor);
            }
            else
            {
                return Conflict("Instructor ID or Email already exists, or invalid Department ID.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstructor(string id, [FromBody] UpdateInstructorDto updateInstructorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _instructorService.UpdateInstructorAsync(id, updateInstructorDto))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(string id)
        {
            if (await _instructorService.DeleteInstructorAsync(id))
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