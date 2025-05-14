// Controllers/AssignmentsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentsController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignmentDto>>> GetAllAssignments()
        {
            var assignments = await _assignmentService.GetAllAssignmentsAsync();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentDto>> GetAssignmentById(int id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        [HttpPost]
        public async Task<ActionResult<AssignmentDto>> CreateAssignment([FromBody] CreateAssignmentDto createAssignmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _assignmentService.CreateAssignmentAsync(createAssignmentDto))
            {
                var createdAssignment = await _assignmentService.GetAssignmentByIdAsync(1); // Assuming ID is auto-generated
                return CreatedAtAction(nameof(GetAssignmentById), new { id = createdAssignment.AssignmentID }, createdAssignment);
            }
            else
            {
                return StatusCode(500, "Failed to create assignment.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, [FromBody] UpdateAssignmentDto updateAssignmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _assignmentService.UpdateAssignmentAsync(id, updateAssignmentDto))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            if (await _assignmentService.DeleteAssignmentAsync(id))
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
