using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Dtos;
using AutoMapper;

namespace server.Services
{
    public class FlashcardService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public FlashcardService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FlashcardDto> CreateFlashcardAsync(FlashcardDto flashcardDto)
        {
            var flashcard = _mapper.Map<Flashcard>(flashcardDto);

            _dbContext.Flashcards.Add(flashcard);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<FlashcardDto>(flashcard);
        }

        public async Task<FlashcardDto> GetFlashcardByIdAsync(int id)
        {
            var flashcard = await _dbContext.Flashcards.FindAsync(id) ?? throw new KeyNotFoundException("Flashcard not found");
            return _mapper.Map<FlashcardDto>(flashcard);
        }
    }
}
