using AutoMapper;
using mipBackend.Dtos.MedidaUmbralDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class MedidaUmbralProfile : Profile
    {

        public MedidaUmbralProfile()
        {

            CreateMap<esp06MedidaUmbral, MedidaUmbralResponseDto>();
            CreateMap<MedidaUmbralResponseDto, esp06MedidaUmbral>();
            CreateMap<MedidaUmbralRequestDto, esp06MedidaUmbral>();

        }

    }
}
