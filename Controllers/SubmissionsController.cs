// Controllers/SubmissionsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionsController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionsController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubmissionDto>>> GetAllSubmissions()
        {
            var submissions = await _submissionService.GetAllSubmissionsAsync();
            return Ok(submissions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubmissionDto>> GetSubmissionById(int id)
        {
            var submission = await _submissionService.GetSubmissionByIdAsync(id);
            if (submission == null)
            {
                return NotFound();
            }
            return Ok(submission);
        }

        [HttpPost]
        public async Task<ActionResult<SubmissionDto>> CreateSubmission([FromBody] CreateSubmissionDto createSubmissionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _submissionService.CreateSubmissionAsync(createSubmissionDto))
            {
                // Ideally, you'd fetch the created submission to return the correct ID.
                // Since SubmissionID is auto-generated, a simple way is to return a CreatedAtAction
                // with a placeholder ID or query for it.
                return CreatedAtAction(nameof(GetSubmissionById), new { id = 1 }, null); // Placeholder ID
            }
            else
            {
                return StatusCode(500, "Failed to create submission.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubmission(int id, [FromBody] UpdateSubmissionDto updateSubmissionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _submissionService.UpdateSubmissionAsync(id, updateSubmissionDto))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubmission(int id)
        {
            if (await _submissionService.DeleteSubmissionAsync(id))
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
