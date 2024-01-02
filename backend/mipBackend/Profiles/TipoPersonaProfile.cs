using AutoMapper;
using mipBackend.Dtos.TipopersonaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipopersonaProfile : Profile
    {
        public TipopersonaProfile()
        {

            CreateMap<per03Tipopersona, TipopersonaResponseDto>();
            CreateMap<TipopersonaResponseDto, per03Tipopersona>();
            CreateMap<TipopersonaRequestDto, per03Tipopersona>();

        }
    }
}