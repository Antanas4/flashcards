using AutoMapper;
using server.Models;
using server.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Flashcard, FlashcardDto>();
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<FlashcardsCollection, FlashcardsCollectionDto>()
                .ForMember(dest => dest.Flashcards, opt => opt.MapFrom(src => src.Flashcards));

    }
}
