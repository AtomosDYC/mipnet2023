using AutoMapper;
using mipBackend.Dtos.TemporadaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TemporadaBaseProfile : Profile
    {

        public TemporadaBaseProfile()
        {

            CreateMap<Temp02TemporadaBase, TemporadaBaseResponseDto>();
            CreateMap<TemporadaBaseResponseDto, Temp02TemporadaBase>();
            CreateMap<TemporadaBaseRequestDto, Temp02TemporadaBase>();

        }

    }
}
