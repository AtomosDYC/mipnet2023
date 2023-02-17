using AutoMapper;
using mipBackend.Dtos.PlantillaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class PlantillaProfile : Profile
    {
        public PlantillaProfile()
        {

            CreateMap<Prf03Plantilla, PlantillaResponseDto>();
            CreateMap<PlantillaRequestDto, Prf03Plantilla>();

        }
    }
}