using AutoMapper;
using mipBackend.Dtos.TipoPerComunicacionDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoPerComunicacionProfile : Profile
    {
        public TipoPerComunicacionProfile()
        {

            CreateMap<Per06TipoPersonaComunicacion, TipoPerComunicacionResponseDto>();
            CreateMap<TipoPerComunicacionResponseDto, Per06TipoPersonaComunicacion>();
            CreateMap<TipoPerComunicacionRequestDto, Per06TipoPersonaComunicacion>();

        }
    }
}