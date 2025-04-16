using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shared.Models;

public class AppDbContext : DbContext
{
    public DbSet<Flashcard> Flashcards { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<FlashcardsCollection> FlashcardsCollection {get; set;}
    public DbSet<StudySession> StudySessions { get; set; }
    public DbSet<StudySessionFlashcard> StudySessionFlashcards { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}

