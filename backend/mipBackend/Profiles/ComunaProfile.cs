using AutoMapper;
using mipBackend.Dtos.ComunaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class ComunaProfile : Profile
    {
        public ComunaProfile()
        {

            CreateMap<sist03Comuna, ComunaResponseDto>();
            CreateMap<ComunaResponseDto, sist03Comuna>();
            CreateMap<ComunaRequestDto, sist03Comuna>();

        }
    }
}
