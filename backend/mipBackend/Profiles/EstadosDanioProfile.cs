using AutoMapper;
using mipBackend.Dtos.EstadosDanioDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class EstadosDanioProfile : Profile
    {
        public EstadosDanioProfile()
        {

            CreateMap<Esp04EstadoDanio, EstadosDanioResponseDto>();
            CreateMap<EstadosDanioResponseDto, Esp04EstadoDanio>();
            CreateMap<EstadosDanioRequestDto, Esp04EstadoDanio>();

        }
    }
}
