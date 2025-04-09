using AutoMapper;
using shared.Models;
using shared.Dtos;

namespace server.MapperProfile
{
    public class FlashcardMapperProfile : Profile
    {
        public FlashcardMapperProfile()
        {
            CreateMap<Flashcard, FlashcardDto>().ReverseMap();
        }
    }
}