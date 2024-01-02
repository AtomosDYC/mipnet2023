using AutoMapper;
using mipBackend.Dtos.TipopermisoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipopermisoProfile : Profile
    {
        public TipopermisoProfile()
        {

            CreateMap<wkf05Tipopermiso, TipopermisoResponseDto>();
            CreateMap<TipopermisoResponseDto, wkf05Tipopermiso>();
            CreateMap<TipopermisoRequestDto, wkf05Tipopermiso>();

        }

    }
}
