using AutoMapper;
using mipBackend.Dtos.PlantillaPerfilDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class PlantillaPerfilProfile : Profile
    {
        public PlantillaPerfilProfile()
        {

            CreateMap<Prf03Plantilla, PlantillaPerfilResponseDto>();
            CreateMap<PlantillaPerfilRequestDto, Prf03Plantilla>();

        }
    }
}
