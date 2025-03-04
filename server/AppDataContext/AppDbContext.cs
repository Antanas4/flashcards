using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using server.Models;

public class AppDbContext : DbContext
{
    public DbSet<Flashcard> Flashcards { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}

