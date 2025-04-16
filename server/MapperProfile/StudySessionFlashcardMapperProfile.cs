using AutoMapper;
using shared.Models;
using shared.Dtos;

namespace server.MapperProfile
{
    public class StudySessionFlashcardMapperProfile : Profile
    {
        public StudySessionFlashcardMapperProfile()
        {
            CreateMap<StudySessionFlashcard, StudySessionFlashcardDto>().ReverseMap();
        }
    }
}
