using AutoMapper;
using mipBackend.Dtos.EstadosDanioDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class EstadosDanioProfile : Profile
    {
        public EstadosDanioProfile()
        {

            CreateMap<esp04EstadoDanio, EstadosDanioResponseDto>();
            CreateMap<EstadosDanioResponseDto, esp04EstadoDanio>();
            CreateMap<EstadosDanioRequestDto, esp04EstadoDanio>();

        }
    }
}
