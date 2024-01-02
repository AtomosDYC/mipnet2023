using AutoMapper;
using mipBackend.Dtos.EspecieDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class EspecieProfile : Profile
    {
        public EspecieProfile()
        {

            CreateMap<esp03especieBase, EspecieResponseDto>();
            CreateMap<EspecieResponseDto, esp03especieBase>();

            CreateMap<esp03especieBase, DatosgeneralesRequestDto>();
            CreateMap<DatosgeneralesRequestDto, esp03especieBase>();

            CreateMap<esp07Union, UnirEspecieRequestDto>();
            CreateMap<UnirEspecieRequestDto, esp07Union>();

            CreateMap<esp01especie, DanioEspecieRequestDto>();
            CreateMap<DanioEspecieRequestDto, esp01especie>();
            CreateMap<DanioEspecieResponseDto, esp01especie>();

            CreateMap<esp05Umbral, UmbralEspecieRequestDto>();
            CreateMap<UmbralEspecieRequestDto, esp05Umbral>();
            CreateMap<UmbralEspecieResponseDto, esp05Umbral>();

        }
    }
}
