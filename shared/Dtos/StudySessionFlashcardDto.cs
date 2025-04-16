namespace shared.Dtos
{
    public class StudySessionFlashcardDto
    {
        public int Id { get; set; }
        public int FlashcardId { get; set; }
        public int CorrectStreak { get; set; }
        public FlashcardDto Flashcard { get; set; }
        public int FlashcardsCollectionId { get; set; }
        public bool LastAnswerCorrect { get; set; }
        public int TimesSeen { get; set; }
    }
}