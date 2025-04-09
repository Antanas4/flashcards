using AutoMapper;
using shared.Models;
using shared.Dtos;

namespace server.MapperProfile
{
    public class FlashcardsCollectionMapperProfile : Profile
    {
        public FlashcardsCollectionMapperProfile()
        {
            CreateMap<FlashcardsCollection, FlashcardsCollectionDto>()
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Flashcards, opt => opt.MapFrom(src => src.Flashcards));

            CreateMap<FlashcardsCollectionDto, FlashcardsCollection>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Flashcards, opt => opt.MapFrom(src => src.Flashcards));
        }
    }
}