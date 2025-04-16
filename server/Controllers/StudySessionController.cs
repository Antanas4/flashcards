using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using server.Services;
using shared.Models;
using shared.Dtos;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudySessionController : ControllerBase
    {
        private readonly StudySessionService _studySessionService;

        public StudySessionController(StudySessionService studySessionService)
        {
            _studySessionService = studySessionService;
        }

        [HttpPost]
        public async Task<ActionResult<StudySessionDto>> CreateStudySessionAsync([FromBody] StartSessionRequestDto request)
        {
            try
            {
                StudySessionDto studySessionDto = await _studySessionService.CreateStudySessionAsync(request);
                return Ok(studySessionDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{studySessionId}/next-flashcard")]
        public async Task<ActionResult<StudySessionFlashcardDto?>> GetNextFlashcard(int studySessionId)
        {
            try
            {
                var flashcard = await _studySessionService.GetNextFlashcardAsync(studySessionId);
                if (flashcard == null)
                    return null;

                return Ok(flashcard);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("{studySessionId}/flashcards/{flashcardId}/answer")]
        public async Task<IActionResult> RegisterAnswer(int studySessionId, int flashcardId, [FromQuery] bool isCorrect)
        {
            try
            {
                await _studySessionService.RegisterAnswerAsync(studySessionId, flashcardId, isCorrect);
                return Ok("Answer registered successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}