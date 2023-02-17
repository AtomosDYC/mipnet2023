using AutoMapper;
using mipBackend.Dtos.ComunaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class ComunaProfile : Profile
    {
        public ComunaProfile()
        {

            CreateMap<Sist03Comuna, ComunaResponseDto>();
            CreateMap<ComunaResponseDto, Sist03Comuna>();
            CreateMap<ComunaRequestDto, Sist03Comuna>();

        }
    }
}
