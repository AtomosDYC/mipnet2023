using AutoMapper;
using mipBackend.Dtos.TipoComPersonaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoComPersonaProfile : Profile
    {
        public TipoComPersonaProfile()
        {

            CreateMap<Per04TipoComunicacion, TipoComPersonaResponseDto>();
            CreateMap<TipoComPersonaResponseDto, Per04TipoComunicacion>();
            CreateMap<TipoComPersonaRequestDto, Per04TipoComunicacion>();

        }
    }
}