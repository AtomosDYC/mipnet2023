using AutoMapper;
using mipBackend.Dtos.EspecieTemporadaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class EspecieTemporadaProfile : Profile
    {
        public EspecieTemporadaProfile()
        {

            CreateMap<esp02Temporadaespecie, EspecieTemporadaResponseDto>();
            CreateMap<EspecieTemporadaResponseDto, esp02Temporadaespecie>();

            CreateMap<esp02Temporadaespecie, EspecieTemporadaRequestDto>();
            CreateMap<EspecieTemporadaRequestDto, esp02Temporadaespecie>();
        }

    }
}
