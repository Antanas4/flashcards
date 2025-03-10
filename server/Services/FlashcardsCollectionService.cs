using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Dtos;
using AutoMapper;

public class FlashcardsCollectionService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public FlashcardsCollectionService(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<FlashcardsCollectionDto>> GetFlashcardsCollectionsAsync()
    {
        var flashcardsCollections = await _dbContext.FlashcardsCollection
            .Include(c => c.Flashcards)
            .ToListAsync();

        return _mapper.Map<List<FlashcardsCollectionDto>>(flashcardsCollections);
    }

    public async Task<FlashcardsCollectionDto> CreateFlashcardsCollectionAsync(FlashcardsCollectionDto flashcardsCollectionDto)
    {
        var flashcardsCollection = _mapper.Map<FlashcardsCollection>(flashcardsCollectionDto);

        _dbContext.FlashcardsCollection.Add(flashcardsCollection);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<FlashcardsCollectionDto>(flashcardsCollection);
    }

    public async Task<FlashcardsCollectionDto> GetFlashcardsCollectionByIdAsync(int id)
    {
        var flashcardsCollection = await _dbContext.FlashcardsCollection
        .Include(c => c.Flashcards)
        .FirstOrDefaultAsync(c => c.Id == id);

        if (flashcardsCollection == null)
        {
            throw new KeyNotFoundException($"Flashcards collection with id {id} not found.");
        }

        return _mapper.Map<FlashcardsCollectionDto>(flashcardsCollection);
    }
}
