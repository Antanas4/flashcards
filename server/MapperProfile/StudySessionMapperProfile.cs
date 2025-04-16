using AutoMapper;
using shared.Models;
using shared.Dtos;

namespace server.MapperProfile
{
    public class StudySessionMapperProfile : Profile
    {
        public StudySessionMapperProfile()
        {
            CreateMap<StudySession, StudySessionDto>().ReverseMap();
        }
    }
}
