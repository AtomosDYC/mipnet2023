using AutoMapper;
using mipBackend.Dtos.TipoCompersonaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoCompersonaProfile : Profile
    {
        public TipoCompersonaProfile()
        {

            CreateMap<per04TipoComunicacion, TipoCompersonaResponseDto>();
            CreateMap<TipoCompersonaResponseDto, per04TipoComunicacion>();
            CreateMap<TipoCompersonaRequestDto, per04TipoComunicacion>();

        }
    }
}