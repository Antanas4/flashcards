using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using shared.Models;
using server.Services;
using shared.Dtos;
using AutoMapper;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardController : ControllerBase
    {
        private readonly FlashcardService _flashcardService;
        private readonly IMapper _mapper;

        public FlashcardController(FlashcardService flashcardService, IMapper mapper)
        {
            _flashcardService = flashcardService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlashcardAsync([FromBody] FlashcardDto flashcardDto)
        {
            if (flashcardDto == null)
                return BadRequest("Invalid data.");

            var createdFlashcardDto = await _flashcardService.CreateFlashcardAsync(flashcardDto);
            return CreatedAtAction(nameof(GetFlashcardByIdAsync), new { id = createdFlashcardDto.Id }, createdFlashcardDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlashcardByIdAsync(int id)
        {
            try
            {
                var flashcardDto = await _flashcardService.GetFlashcardByIdAsync(id);
                return Ok(flashcardDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
