using shared.Models;

namespace server.Services
{
    public class CorrectStreakHandler : IStudySessionModeHandler
    {
        public bool IsSessionComplete(StudySession session)
        {
            return session.Flashcards.All(f => f.CorrectStreak >= 2);
        }

        public StudySessionFlashcard GetNextFlashcard(StudySession session)
        {
            var candidates = session.Flashcards.Where(f => f.CorrectStreak < 2).ToList();
            return candidates[new Random().Next(candidates.Count)];
        }

        public void RegisterAnswer(StudySessionFlashcard flashcard, bool isCorrect)
        {
            flashcard.TimesSeen++;
            flashcard.LastAnswerCorrect = isCorrect;

            if (isCorrect)
                flashcard.CorrectStreak++;
            else
                flashcard.CorrectStreak = 0;
        }
    }
}