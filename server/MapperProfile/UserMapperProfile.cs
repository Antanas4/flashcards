using AutoMapper;
using shared.Models;
using shared.Dtos;

namespace server.MapperProfile
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}