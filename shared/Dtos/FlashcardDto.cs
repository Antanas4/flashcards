using System.ComponentModel.DataAnnotations;

namespace shared.Dtos
{
    public class FlashcardDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Question is required")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Answer is required")]
        public string Answer { get; set; }

        public int CorrectAnswerStreak { get; set; }
    }
}
