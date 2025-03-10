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
        var flashcardsCollections = await _dbContext.FlashcardsCollections
            .Include(c => c.Flashcards)
            .ToListAsync();

        return _mapper.Map<List<FlashcardsCollectionDto>>(flashcardsCollections);
    }

    public async Task<FlashcardsCollectionDto> CreateFlashcardsCollectionAsync(FlashcardsCollectionDto collectionDto)
    {
        var flashcardsCollection = _mapper.Map<FlashcardsCollection>(collectionDto);

        _dbContext.FlashcardsCollections.Add(flashcardsCollection);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<FlashcardsCollectionDto>(flashcardsCollection);
    }
}
