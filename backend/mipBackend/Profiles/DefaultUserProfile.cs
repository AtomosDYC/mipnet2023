using AutoMapper;
using mipBackend.Dtos.DefaultUserDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class DefaultUserProfile : Profile
    {
        public DefaultUserProfile()
        {

            CreateMap<Per09DefaultUser, DefaultUserResponseDto>();
            CreateMap<DefaultUserResponseDto, Per09DefaultUser>();
            CreateMap<DefaultUserRequestDto, Per09DefaultUser>();

        }
    }
}
