using AutoMapper;
using mipBackend.Dtos.TemporadaDtos;
using mipBackend.Models;


namespace mipBackend.Profiles
{
    public class TemporadaProfile : Profile
    {
        public TemporadaProfile()
        {

            CreateMap<Temp01Temporada, TemporadaResponseDto>();
            CreateMap<TemporadaRequestDto, Temp01Temporada>();
            CreateMap<TemporadaResponseDto, Temp01Temporada>();

        }
    }
}
