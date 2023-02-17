using AutoMapper;
using mipBackend.Dtos.ZonaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class ZonaProfile : Profile
    {
        public ZonaProfile()
        {

            CreateMap<Sist02Zona, ZonaResponseDto>();
            CreateMap<ZonaResponseDto, Sist02Zona>();
            CreateMap<ZonaRequestDto, Sist02Zona>();
        }
    }
}
