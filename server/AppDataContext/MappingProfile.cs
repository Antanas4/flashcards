using AutoMapper;
using server.Models;
using server.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Flashcard, FlashcardDto>();
    }
}
