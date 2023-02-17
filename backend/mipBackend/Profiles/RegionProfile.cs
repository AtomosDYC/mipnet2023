using AutoMapper;
using mipBackend.Dtos.RegionDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {

            CreateMap<Sist04Region, RegionResponseDto>();
            CreateMap<RegionResponseDto, Sist04Region>();
            CreateMap<RegionRequestDto, Sist04Region>();

        }
    }
}
