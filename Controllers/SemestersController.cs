// Controllers/SemestersController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SemestersController : ControllerBase
    {
        private readonly ISemesterService _semesterService;

        public SemestersController(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SemesterDto>>> GetAllSemesters()
        {
            var semesters = await _semesterService.GetAllSemestersAsync();
            return Ok(semesters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterDto>> GetSemesterById(string id)
        {
            var semester = await _semesterService.GetSemesterByIdAsync(id);
            if (semester == null)
            {
                return NotFound();
            }
            return Ok(semester);
        }

        [HttpPost]
        public async Task<ActionResult<SemesterDto>> CreateSemester([FromBody] CreateSemesterDto createSemesterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _semesterService.CreateSemesterAsync(createSemesterDto))
            {
                var createdSemester = await _semesterService.GetSemesterByIdAsync(createSemesterDto.SemesterID);
                return CreatedAtAction(nameof(GetSemesterById), new { id = createdSemester.SemesterID }, createdSemester);
            }
            else
            {
                return Conflict("Semester ID already exists.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSemester(string id, [FromBody] UpdateSemesterDto updateSemesterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _semesterService.UpdateSemesterAsync(id, updateSemesterDto))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(string id)
        {
            if (await _semesterService.DeleteSemesterAsync(id))
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
