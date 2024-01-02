using AutoMapper;
using mipBackend.Dtos.PlantillaFlujoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class PlantillaFlujoProfile : Profile
    {
        public PlantillaFlujoProfile()
        {

            CreateMap<prf04PlantillaFlujo, PlantillaFlujoResponseDto>();
            CreateMap<PlantillaFlujoRequestDto, prf04PlantillaFlujo>();

        }
    }
}
