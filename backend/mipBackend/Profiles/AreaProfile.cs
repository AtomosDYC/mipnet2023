using AutoMapper;
using mipBackend.Dtos.AreaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {

            CreateMap<Wkf08Area, AreaResponseDto>();
            CreateMap<AreaResponseDto, Wkf08Area>();
            CreateMap<AreaRequestDto, Wkf08Area>();

        }
    }
}
