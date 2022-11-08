using AutoMapper;
using mipBackend.Dtos.InmuebleDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class InmuebleProfile : Profile
    {

        public InmuebleProfile()
        {

            CreateMap<Inmueble, InmuebleResponseDto>();
            CreateMap<InmuebleRequestDto, Inmueble>();

        }

    }
}
