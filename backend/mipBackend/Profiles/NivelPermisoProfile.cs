using AutoMapper;
using mipBackend.Dtos.NivelPermisoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class NivelPermisoProfile : Profile
    {
        public NivelPermisoProfile()
        {

            CreateMap<Wkf04NivelPermiso, NivelPermisoResponseDto>();
            CreateMap<NivelPermisoResponseDto, Wkf04NivelPermiso>();
            CreateMap<NivelPermisoRequestDto, Wkf04NivelPermiso>();

        }
    }
}
