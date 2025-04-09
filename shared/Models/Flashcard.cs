using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shared.Models
{
    public class Flashcard
    {
        private int _id;
        private string _question;
        private string _answer;
        private int _correctAnswerStreak;
        private FlashcardsCollection _flashcardsCollection;

        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public FlashcardsCollection FlashcardsCollection
        {
            get => _flashcardsCollection;
            set => _flashcardsCollection = value;
        }

        public required string Question
        {
            get => _question;
            set => _question = value;
        }

        public required string Answer
        {
            get => _answer;
            set => _answer = value;
        }

        public int CorrectAnswerStreak
        {
            get => _correctAnswerStreak;
            set => _correctAnswerStreak = value;
        }

        public Flashcard(string question, string answer)
        {
            _question = question;
            _answer = answer;
        }
    }
}
