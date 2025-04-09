using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shared.Models;
using shared.Dtos;
using AutoMapper;

namespace server.Services
{

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
                .Include(c => c.User)
                .ToListAsync();

            return _mapper.Map<List<FlashcardsCollectionDto>>(flashcardsCollections);
        }

        public async Task<FlashcardsCollectionDto> CreateFlashcardsCollectionAsync(FlashcardsCollectionDto flashcardsCollectionDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == flashcardsCollectionDto.OwnerId);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found with id " + flashcardsCollectionDto.OwnerId);
            }

            var flashcardsCollection = new FlashcardsCollection
            {
                Name = flashcardsCollectionDto.Name,
                Description = flashcardsCollectionDto.Description,
                User = user,
                Flashcards = flashcardsCollectionDto.Flashcards?.Select(fcDto => _mapper.Map<Flashcard>(fcDto)).ToList()
            };

            _dbContext.FlashcardsCollection.Add(flashcardsCollection);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<FlashcardsCollectionDto>(flashcardsCollection);
        }

        public async Task<FlashcardsCollectionDto> GetFlashcardsCollectionByIdAsync(int id)
        {
            var flashcardsCollection = await _dbContext.FlashcardsCollection
            .Include(c => c.Flashcards)
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.Id == id);

            if (flashcardsCollection == null)
            {
                throw new KeyNotFoundException($"Flashcards collection with id {id} not found.");
            }

            return _mapper.Map<FlashcardsCollectionDto>(flashcardsCollection);
        }

        public async Task<bool> DeleteFlashcardsCollectionByIdAsync(int id)
        {
            var flashcardsCollection = await _dbContext.FlashcardsCollection.FindAsync(id);

            if (flashcardsCollection == null)
            {
                throw new KeyNotFoundException("Collection not found");
            }

            _dbContext.FlashcardsCollection.Remove(flashcardsCollection);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateFlashcardsCollectionByIdAsync(FlashcardsCollectionDto updatedCollectionDto)
        {
            var collectionToUpdate = await _dbContext.FlashcardsCollection
                .Include(c => c.Flashcards)
                .FirstOrDefaultAsync(c => c.Id == updatedCollectionDto.Id);

            if (collectionToUpdate == null)
            {
                throw new KeyNotFoundException("Collection not found");
            }

            collectionToUpdate.Name = updatedCollectionDto.Name;
            collectionToUpdate.Description = updatedCollectionDto.Description;

            foreach (var updatedFlashcard in updatedCollectionDto.Flashcards)
            {
                var existingFlashcard = collectionToUpdate.Flashcards
                    .FirstOrDefault(f => f.Id == updatedFlashcard.Id);

                if (existingFlashcard != null)
                {
                    existingFlashcard.Question = updatedFlashcard.Question;
                    existingFlashcard.Answer = updatedFlashcard.Answer;
                }
                else
                {
                    var newFlashcard = _mapper.Map<Flashcard>(updatedFlashcard);
                    collectionToUpdate.Flashcards.Add(newFlashcard);
                }
            }

            var flashcardsToRemove = collectionToUpdate.Flashcards
                .Where(f => !updatedCollectionDto.Flashcards.Any(uf => uf.Id == f.Id))
                .ToList();

            foreach (var flashcardToRemove in flashcardsToRemove)
            {
                _dbContext.Flashcards.Remove(flashcardToRemove);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
