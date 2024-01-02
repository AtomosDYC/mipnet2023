using AutoMapper;
using mipBackend.Dtos.TipoParametroDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoParametroProfile : Profile
    {
        public TipoParametroProfile()
        {

            CreateMap<wkf10TipoParametro, TipoParametroResponseDto>();
            CreateMap<TipoParametroResponseDto, wkf10TipoParametro>();
            CreateMap<TipoParametroRequestDto, wkf10TipoParametro>();

        }
    }
}
