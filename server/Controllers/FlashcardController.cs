using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using server.Models;

[Route("api/[controller]")]
[ApiController]
public class FlashcardController : ControllerBase
{
    private readonly FlashcardService _flashcardService;

    public FlashcardController(FlashcardService flashcardService)
    {
        _flashcardService = flashcardService;
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
        var flashcard = await _flashcardService.GetFlashcardByIdAsync(id);
        if (flashcard == null)
            return NotFound();

        return Ok(flashcard);
    }
}
