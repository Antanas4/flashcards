using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shared.Models
{
    public class StudySessionFlashcard
    {
        private int _id;
        private int _flashcardId;
        private Flashcard _flashcard;
        private int _correctStreak;
        private int _flashcardsCollectionId;
        private FlashcardsCollection _flashcardsCollection;
        private bool _lastAnswerCorrect;
        private int _timesSeen;

        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int FlashcardId
        {
            get => _flashcardId;
            set => _flashcardId = value;
        }

        public Flashcard Flashcard
        {
            get => _flashcard;
            set => _flashcard = value;
        }

        public int CorrectStreak
        {
            get => _correctStreak;
            set => _correctStreak = value;
        }

        public int FlashcardsCollectionId
        {
            get => _flashcardsCollectionId;
            set => _flashcardsCollectionId = value;
        }

        public FlashcardsCollection FlashcardsCollection
        {
            get => _flashcardsCollection;
            set => _flashcardsCollection = value;
        }
        public bool LastAnswerCorrect
        {
            get => _lastAnswerCorrect;
            set => _lastAnswerCorrect = value;
        }

        public int TimesSeen
        {
            get => _timesSeen;
            set => _timesSeen = value;
        }

        public StudySessionFlashcard() {}

        public StudySessionFlashcard(int flashcardId, Flashcard flashcard, int correctStreak, int flashcardsCollectionId)
        {
            _flashcardId = flashcardId;
            _flashcard = flashcard;
            _correctStreak = correctStreak;
            _flashcardsCollectionId = flashcardsCollectionId;
        }
    }
}
