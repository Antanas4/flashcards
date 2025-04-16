using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shared.Models;
using shared.Dtos;
using shared.Enums;
using AutoMapper;
using System.ComponentModel;

namespace server.Services
{
    public class StudySessionService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly AuthService _authService;
        private readonly Func<StudySessionMode, IStudySessionModeHandler> _modeHandlerFactory;

        public StudySessionService(AppDbContext dbContext, IMapper mapper, AuthService authService, Func<StudySessionMode, IStudySessionModeHandler> modeHandlerFactory)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authService = authService;
            _modeHandlerFactory = modeHandlerFactory;
        }

        public async Task<StudySessionDto> CreateStudySessionAsync(StartSessionRequestDto request)
        {

            var flashcards = await _dbContext.Flashcards
                .Include(f => f.FlashcardsCollection)
                .Where(f => f.FlashcardsCollection.Id == request.CollectionId)
                .ToListAsync();

            if (flashcards == null || !flashcards.Any())
            {
                throw new InvalidOperationException($"No flashcards found for the specified collection., {request.CollectionId} {request.StudySessionMode}");
            }

            var sessionFlashcards = flashcards.Select(f => new StudySessionFlashcard
            {
                FlashcardId = f.Id,
                Flashcard = f,
                FlashcardsCollectionId = f.FlashcardsCollection.Id,
                CorrectStreak = 0,
                LastAnswerCorrect = false,
                TimesSeen = 0
            }).ToList();

            var studySession = new StudySession
            {
                StudySessionMode = request.StudySessionMode,
                IsCompleted = false,
                Flashcards = sessionFlashcards
            };

            _dbContext.StudySessions.Add(studySession);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<StudySessionDto>(studySession);
        }

        public async Task<StudySessionFlashcardDto?> GetNextFlashcardAsync(int studySessionId)
        {
            var session = await _dbContext.StudySessions
                .Include(s => s.Flashcards)
                .ThenInclude(f => f.Flashcard)
                .FirstOrDefaultAsync(s => s.Id == studySessionId);

            if (session == null)
                throw new KeyNotFoundException($"Study session with ID {studySessionId} not found.");

            var modeHandler = _modeHandlerFactory(session.StudySessionMode);

            if (modeHandler.IsSessionComplete(session))
            {
                session.IsCompleted = true;
                await _dbContext.SaveChangesAsync();
                return null;
            }

            var nextFlashcard = modeHandler.GetNextFlashcard(session);

            if (nextFlashcard == null)
                return null;

            return _mapper.Map<StudySessionFlashcardDto>(nextFlashcard);
        }

        public async Task RegisterAnswerAsync(int studySessionId, int flashcardId, bool isCorrect)
        {
            var session = await _dbContext.StudySessions
                .Include(s => s.Flashcards)
                .ThenInclude(f => f.Flashcard)
                .FirstOrDefaultAsync(s => s.Id == studySessionId);

            if (session == null)
                throw new KeyNotFoundException($"Study session with ID {studySessionId} not found.");

            var flashcard = session.Flashcards.FirstOrDefault(f => f.FlashcardId == flashcardId);

            if (flashcard == null)
                throw new KeyNotFoundException($"Flashcard with ID {flashcardId} not found in the study session.");

            var modeHandler = _modeHandlerFactory(session.StudySessionMode);
            modeHandler.RegisterAnswer(flashcard, isCorrect);

            await _dbContext.SaveChangesAsync();
        }
    }
}