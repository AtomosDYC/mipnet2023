using AutoMapper;
using mipBackend.Dtos.PersonaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {

            CreateMap<per01persona, PersonaResponseDto>();
            CreateMap<PersonaResponseDto, per01persona>();

            CreateMap<per01persona, PersonaRequestDto>();
            CreateMap<PersonaRequestDto, per01persona>();


            CreateMap<per05Comunicacion, PersonaComunicacionResponseDto>();
            CreateMap<PersonaComunicacionResponseDto, per05Comunicacion>();

            CreateMap<per05Comunicacion, PersonaComunicacionRequestDto>();
            CreateMap<PersonaComunicacionRequestDto, per05Comunicacion>();


        }
    }
}
