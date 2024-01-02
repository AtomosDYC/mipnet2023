using AutoMapper;
using mipBackend.Dtos.TipoespecieDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoespecieProfile : Profile
    {
        public TipoespecieProfile()
        {

            CreateMap<esp08TipoBase, TipoespecieResponseDto>();
            CreateMap<TipoespecieResponseDto, esp08TipoBase>();
            CreateMap<TipoespecieRequestDto, esp08TipoBase>();

        }
    }
}
