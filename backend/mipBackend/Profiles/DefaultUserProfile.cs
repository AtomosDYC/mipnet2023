using AutoMapper;
using mipBackend.Dtos.DefaultUserDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class DefaultUserProfile : Profile
    {
        public DefaultUserProfile()
        {

            CreateMap<per09DefaultUser, DefaultUserResponseDto>();
            CreateMap<DefaultUserResponseDto, per09DefaultUser>();
            CreateMap<DefaultUserRequestDto, per09DefaultUser>();

        }
    }
}
