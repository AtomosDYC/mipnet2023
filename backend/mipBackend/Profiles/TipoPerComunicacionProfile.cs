using AutoMapper;
using mipBackend.Dtos.TipoperComunicacionDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoperComunicacionProfile : Profile
    {
        public TipoperComunicacionProfile()
        {

            CreateMap<per06TipopersonaComunicacion, TipoperComunicacionResponseDto>();
            CreateMap<TipoperComunicacionResponseDto, per06TipopersonaComunicacion>();
            CreateMap<TipoperComunicacionRequestDto, per06TipopersonaComunicacion>();

        }
    }
}