using AutoMapper;
using mipBackend.Dtos.NivelFlujoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class NivelFlujoProfile : Profile
    {
        public NivelFlujoProfile()
        {

            CreateMap<Wkf03Nivel, NivelFlujoResponseDto>();
            CreateMap<NivelFlujoResponseDto, Wkf03Nivel>();
            CreateMap<NivelFlujoRequestDto, Wkf03Nivel>();

        }

    }
}
