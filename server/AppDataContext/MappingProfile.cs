using AutoMapper;
using server.Models;
using server.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Flashcard, FlashcardDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();

        CreateMap<FlashcardsCollection, FlashcardsCollectionDto>()
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Flashcards, opt => opt.MapFrom(src => src.Flashcards));

        CreateMap<FlashcardsCollectionDto, FlashcardsCollection>()
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Flashcards, opt => opt.MapFrom(src => src.Flashcards));
    }
}
