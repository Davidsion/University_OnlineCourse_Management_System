// Controllers/TimetablesController.cs
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
    public class TimetablesController : ControllerBase
    {
        private readonly ITimetableService _timetableService;

        public TimetablesController(ITimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimetableDto>>> GetAllTimetables()
        {
            var timetables = await _timetableService.GetAllTimetablesAsync();
            return Ok(timetables);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimetableDto>> GetTimetableById(int id)
        {
            var timetable = await _timetableService.GetTimetableByIdAsync(id);
            if (timetable == null)
            {
                return NotFound();
            }
            return Ok(timetable);
        }

        [HttpPost]
        public async Task<ActionResult<TimetableDto>> CreateTimetable([FromBody] CreateTimetableDto createTimetableDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _timetableService.CreateTimetableAsync(createTimetableDto))
            {
                var createdTimetable = await _timetableService.GetTimetableByIdAsync(1); // Assuming ID is auto-generated
                return CreatedAtAction(nameof(GetTimetableById), new { id = createdTimetable.TimetableID }, createdTimetable);
            }
            else
            {
                return StatusCode(500, "Failed to create timetable slot.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimetable(int id, [FromBody] UpdateTimetableDto updateTimetableDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _timetableService.UpdateTimetableAsync(id, updateTimetableDto))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimetable(int id)
        {
            if (await _timetableService.DeleteTimetableAsync(id))
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
