using AutoMapper;
using mipBackend.Dtos.TipoCuentaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoCuentaProfile : Profile
    {
        public TipoCuentaProfile()
        {

            CreateMap<Cnt02TipoCuenta, TipoCuentaResponseDto>();
            CreateMap<TipoCuentaResponseDto, Cnt02TipoCuenta>();
            CreateMap<TipoCuentaRequestDto, Cnt02TipoCuenta>();

        }
    }
}
