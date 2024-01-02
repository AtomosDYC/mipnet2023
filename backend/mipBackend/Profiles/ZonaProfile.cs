using AutoMapper;
using mipBackend.Dtos.ZonaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class ZonaProfile : Profile
    {
        public ZonaProfile()
        {

            CreateMap<sist02Zona, ZonaResponseDto>();
            CreateMap<ZonaResponseDto, sist02Zona>();
            CreateMap<ZonaRequestDto, sist02Zona>();
        }
    }
}
