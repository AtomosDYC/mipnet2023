using AutoMapper;
using mipBackend.Dtos.TipoFlujoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoFlujoProfile : Profile
    {
        public TipoFlujoProfile()
        {

            CreateMap<wkf02TipoFlujo, TipoFlujoResponseDto>();
            CreateMap<TipoFlujoResponseDto, wkf02TipoFlujo>();
            CreateMap<TipoFlujoRequestDto, wkf02TipoFlujo>();

        }
    }
}
