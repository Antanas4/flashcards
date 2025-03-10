using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using server.Models;
using server.Services;
using server.Dtos;
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
        public async Task<IActionResult> CreateFlashcard([FromBody] Flashcard flashcard)
        {
            if (flashcard == null)
                return BadRequest("Invalid data.");

            var createdFlashcard = await _flashcardService.CreateFlashcardAsync(flashcard);
            return CreatedAtAction(nameof(GetFlashcard), new { id = createdFlashcard.Id }, createdFlashcard);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlashcard(int id)
        {
            var flashcard = await _flashcardService.GetFlashcardByIdAsync(id: id);
            if (flashcard == null)
                return NotFound();

            var flashcardDto = _mapper.Map<FlashcardDto>(flashcard);
            return Ok(flashcardDto);
        }
    }
}
