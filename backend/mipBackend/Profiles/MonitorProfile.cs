using AutoMapper;
using mipBackend.Dtos.MonitorDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class MonitorProfile : Profile
    {
        public MonitorProfile()
        {

            CreateMap<Mnt01Monitor, MonitorResponseDto>();
            CreateMap<MonitorResponseDto, Mnt01Monitor>();

            CreateMap<Mnt01Monitor, MonitorRequestDto>();
            CreateMap<MonitorRequestDto, Mnt01Monitor>();

            CreateMap<per05Comunicacion, MonitorComunicacionResponseDto>();
            CreateMap<MonitorComunicacionResponseDto, per05Comunicacion>();
        }
    }
}
