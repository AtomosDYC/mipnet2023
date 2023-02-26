using AutoMapper;
using mipBackend.Dtos.TipoPersonaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoPersonaProfile : Profile
    {
        public TipoPersonaProfile()
        {

            CreateMap<Per03TipoPersona, TipoPersonaResponseDto>();
            CreateMap<TipoPersonaResponseDto, Per03TipoPersona>();
            CreateMap<TipoPersonaRequestDto, Per03TipoPersona>();

        }
    }
}