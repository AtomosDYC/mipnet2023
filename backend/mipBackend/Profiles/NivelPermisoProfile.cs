using AutoMapper;
using mipBackend.Dtos.NivelpermisoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class NivelpermisoProfile : Profile
    {
        public NivelpermisoProfile()
        {

            CreateMap<wkf04Nivelpermiso, NivelpermisoResponseDto>();
            CreateMap<NivelpermisoResponseDto, wkf04Nivelpermiso>();
            CreateMap<NivelpermisoRequestDto, wkf04Nivelpermiso>();

        }
    }
}
