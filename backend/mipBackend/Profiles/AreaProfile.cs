using AutoMapper;
using mipBackend.Dtos.AreaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {

            CreateMap<wkf08Area, AreaResponseDto>();
            CreateMap<AreaResponseDto, wkf08Area>();
            CreateMap<AreaRequestDto, wkf08Area>();

        }
    }
}
