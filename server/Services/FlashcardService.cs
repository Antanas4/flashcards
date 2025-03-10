using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Services
{
    public class FlashcardService
    {
        private readonly AppDbContext _dbContext;

        public FlashcardService(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Flashcard> CreateFlashcardAsync(Flashcard flashcard)
        {
            _dbContext.Flashcards.Add(flashcard);
            await _dbContext.SaveChangesAsync();
            return flashcard;
        }

        public async Task<Flashcard?> GetFlashcardByIdAsync(int id)
        {
            return await _dbContext.Flashcards.FindAsync(id);
        }
    }
}
