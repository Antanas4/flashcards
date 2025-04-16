using shared.Enums;

namespace shared.Dtos
{
    public class StudySessionDto
    {
        public int Id { get; set; }
        public StudySessionMode Mode { get; set; }
        public bool IsCompleted { get; set; }
        public List<StudySessionFlashcardDto> Flashcards { get; set; } = new();
    }
}
