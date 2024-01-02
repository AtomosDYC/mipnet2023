using AutoMapper;
using mipBackend.Dtos.PlantillaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class PlantillaProfile : Profile
    {
        public PlantillaProfile()
        {

            CreateMap<prf03Plantilla, PlantillaResponseDto>();
            CreateMap<PlantillaRequestDto, prf03Plantilla>();

        }
    }
}