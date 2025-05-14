using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryResourcesController : ControllerBase
    {
        private readonly ILibraryResourceService _libraryResourceService;

        public LibraryResourcesController(ILibraryResourceService libraryResourceService)
        {
            _libraryResourceService = libraryResourceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibraryResourceDto>>> GetAllLibraryResources()
        {
            var libraryResources = await _libraryResourceService.GetAllLibraryResourcesAsync();
            return Ok(libraryResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryResourceDto>> GetLibraryResourceById(int id)
        {
            var libraryResource = await _libraryResourceService.GetLibraryResourceByIdAsync(id);
            if (libraryResource == null)
            {
                return NotFound();
            }
            return Ok(libraryResource);
        }

        [HttpPost]
        public async Task<ActionResult<LibraryResourceDto>> CreateLibraryResource([FromBody] CreateLibraryResourceDto createLibraryResourceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _libraryResourceService.CreateLibraryResourceAsync(createLibraryResourceDto))
            {
                var createdResource = await _libraryResourceService.GetLibraryResourceByIdAsync(1); // Assuming ID is auto-generated
                return CreatedAtAction(nameof(GetLibraryResourceById), new { id = createdResource.ResourceID }, createdResource);
            }
            else
            {
                return StatusCode(500, "Failed to create library resource.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLibraryResource(int id, [FromBody] UpdateLibraryResourceDto updateLibraryResourceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _libraryResourceService.UpdateLibraryResourceAsync(id, updateLibraryResourceDto))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibraryResource(int id)
        {
            if (await _libraryResourceService.DeleteLibraryResourceAsync(id))
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