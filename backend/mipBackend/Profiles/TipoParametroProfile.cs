using AutoMapper;
using mipBackend.Dtos.TipoParametroDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoParametroProfile : Profile
    {
        public TipoParametroProfile()
        {

            CreateMap<Wkf10TipoParametro, TipoParametroResponseDto>();
            CreateMap<TipoParametroResponseDto, Wkf10TipoParametro>();
            CreateMap<TipoParametroRequestDto, Wkf10TipoParametro>();

        }
    }
}
