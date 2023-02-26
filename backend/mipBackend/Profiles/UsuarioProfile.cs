using AutoMapper;
using mipBackend.Dtos.UsuarioDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {

            CreateMap<Usuario, UsuarioResponseDto>();
            CreateMap<UsuarioResponseDto, Usuario>();
            

        }
    }
}

