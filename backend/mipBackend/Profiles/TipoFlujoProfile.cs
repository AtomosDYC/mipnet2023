using AutoMapper;
using mipBackend.Dtos.TipoFlujoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoFlujoProfile : Profile
    {
        public TipoFlujoProfile()
        {

            CreateMap<Wkf02TipoFlujo, TipoFlujoResponseDto>();
            CreateMap<TipoFlujoResponseDto, Wkf02TipoFlujo>();
            CreateMap<TipoFlujoRequestDto, Wkf02TipoFlujo>();

        }
    }
}
