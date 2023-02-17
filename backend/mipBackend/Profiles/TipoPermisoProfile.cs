using AutoMapper;
using mipBackend.Dtos.TipoPermisoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoPermisoProfile : Profile
    {
        public TipoPermisoProfile()
        {

            CreateMap<Wkf05TipoPermiso, TipoPermisoResponseDto>();
            CreateMap<TipoPermisoResponseDto, Wkf05TipoPermiso>();
            CreateMap<TipoPermisoRequestDto, Wkf05TipoPermiso>();

        }

    }
}
