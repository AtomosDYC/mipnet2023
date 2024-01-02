using AutoMapper;
using mipBackend.Dtos.NivelFlujoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class NivelFlujoProfile : Profile
    {
        public NivelFlujoProfile()
        {

            CreateMap<wkf03Nivel, NivelFlujoResponseDto>();
            CreateMap<NivelFlujoResponseDto, wkf03Nivel>();
            CreateMap<NivelFlujoRequestDto, wkf03Nivel>();

        }

    }
}
