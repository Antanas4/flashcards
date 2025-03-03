using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using server.Dto;

namespace WebApiProject.Controllers
{
    [Route("api/flashcard")]
    [ApiController]
    public class FlashcardController : ControllerBase
    {
        private static List<Flashcard> _flashcards = new List<Flashcard>
        {
            new Flashcard { Id = 1, Question = "Flashcard 1", Answer = "answer" },
            new Flashcard { Id = 2, Question = "Flashcard 2", Answer = "answer" }
        };

        [HttpGet]
        public IActionResult GetFlashcards()
        {
            var flashcardDtos = _flashcards.Select(f => new FlashcardDto            {
                Id = f.Id,
                Question = f.Question,
                Answer = f.Answer
            }).ToList();

            return Ok(flashcardDtos);
        }
    }
}
