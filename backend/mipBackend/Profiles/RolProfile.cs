using AutoMapper;
using mipBackend.Dtos.RolDtos;
using mipBackend.Models;
using Microsoft.AspNetCore.Identity;

namespace mipBackend.Profiles
{
    public class RolProfile : Profile
    {
        public RolProfile()
        {

            CreateMap<Rol, RolResponseDto>();
            CreateMap<IdentityRole, RolResponseDto>();
            CreateMap<RolRequestDto, Rol>();
           
        }
    }
}
