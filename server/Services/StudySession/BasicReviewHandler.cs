using shared.Models;

namespace server.Services
{
    public class BasicReviewHandler : IStudySessionModeHandler
    {
        public bool IsSessionComplete(StudySession session)
        {
            return session.Flashcards.All(f => f.TimesSeen > 0);
        }

        public StudySessionFlashcard GetNextFlashcard(StudySession session)
        {
            return session.Flashcards.FirstOrDefault(f => f.TimesSeen == 0);
        }

        public void RegisterAnswer(StudySessionFlashcard flashcard, bool isCorrect)
        {
            flashcard.TimesSeen++;
            flashcard.LastAnswerCorrect = isCorrect;
        }
    }
}