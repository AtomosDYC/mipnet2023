using AutoMapper;
using mipBackend.Dtos.SaludoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class SaludoProfile : Profile
    {
        public SaludoProfile()
        {

            CreateMap<Per02Genero, SaludoResponseDto>();
            CreateMap<SaludoResponseDto, Per02Genero>();
            CreateMap<SaludoRequestDto, Per02Genero>();

        }
    }
}

