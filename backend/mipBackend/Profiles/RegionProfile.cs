using AutoMapper;
using mipBackend.Dtos.RegionDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {

            CreateMap<sist04Region, RegionResponseDto>();
            CreateMap<RegionResponseDto, sist04Region>();
            CreateMap<RegionRequestDto, sist04Region>();

        }
    }
}
