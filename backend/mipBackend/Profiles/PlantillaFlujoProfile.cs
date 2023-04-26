using AutoMapper;
using mipBackend.Dtos.PlantillaFlujoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class PlantillaFlujoProfile : Profile
    {
        public PlantillaFlujoProfile()
        {

            CreateMap<Prf04PlantillaFlujo, PlantillaFlujoResponseDto>();
            CreateMap<PlantillaFlujoRequestDto, Prf04PlantillaFlujo>();

        }
    }
}
