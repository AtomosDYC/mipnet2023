using AutoMapper;
using mipBackend.Dtos.TipoEspecieDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoEspecieProfile : Profile
    {
        public TipoEspecieProfile()
        {

            CreateMap<Esp08TipoBase, TipoEspecieResponseDto>();
            CreateMap<TipoEspecieResponseDto, Esp08TipoBase>();
            CreateMap<TipoEspecieRequestDto, Esp08TipoBase>();

        }
    }
}
