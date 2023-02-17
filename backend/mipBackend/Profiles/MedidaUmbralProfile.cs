using AutoMapper;
using mipBackend.Dtos.MedidaUmbralDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class MedidaUmbralProfile : Profile
    {

        public MedidaUmbralProfile()
        {

            CreateMap<Esp06MedidaUmbral, MedidaUmbralResponseDto>();
            CreateMap<MedidaUmbralResponseDto, Esp06MedidaUmbral>();
            CreateMap<MedidaUmbralRequestDto, Esp06MedidaUmbral>();

        }

    }
}
