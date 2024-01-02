using AutoMapper;
using mipBackend.Dtos.TipoCuentaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoCuentaProfile : Profile
    {
        public TipoCuentaProfile()
        {

            CreateMap<cnt02TipoCuenta, TipoCuentaResponseDto>();
            CreateMap<TipoCuentaResponseDto, cnt02TipoCuenta>();
            CreateMap<TipoCuentaRequestDto, cnt02TipoCuenta>();

        }
    }
}
