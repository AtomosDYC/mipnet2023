using AutoMapper;
using mipBackend.Dtos.SetSelectDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class SetSelectProfile : Profile
    {
        public SetSelectProfile()
        {

            CreateMap<setSelect, SetSelectResponseDto>();
            CreateMap<SetSelectRequestDto, setSelect>();

        }
    }
}
