using shared.Models;

namespace server.Services
{
    public interface IStudySessionModeHandler
    {
        bool IsSessionComplete(StudySession session);
        StudySessionFlashcard GetNextFlashcard(StudySession session);
        void RegisterAnswer(StudySessionFlashcard flashcard, bool isCorrect);
    }
}

