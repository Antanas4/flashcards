using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models;

public class FlashcardService
{
    private readonly AppDbContext _context;

    public FlashcardService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Flashcard> CreateFlashcardAsync(Flashcard flashcard)
    {
        _context.Flashcards.Add(flashcard);
        await _context.SaveChangesAsync();
        return flashcard;
    }

    public async Task<Flashcard> GetFlashcardByIdAsync(int id)
    {
        return await _context.Flashcards.FindAsync(id);
    }
}
