using AutoMapper;
using mipBackend.Dtos.SaludoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class SaludoProfile : Profile
    {
        public SaludoProfile()
        {

            CreateMap<per02Genero, SaludoResponseDto>();
            CreateMap<SaludoResponseDto, per02Genero>();
            CreateMap<SaludoRequestDto, per02Genero>();

        }
    }
}

