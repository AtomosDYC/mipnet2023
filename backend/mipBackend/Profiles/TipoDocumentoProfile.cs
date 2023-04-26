using AutoMapper;
using mipBackend.Dtos.TipoDocumentoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoDocumentoProfile : Profile
    {
        public TipoDocumentoProfile()
        {

            CreateMap<Per08TipoDocumento, TipoDocumentoResponseDto>();
            CreateMap<TipoDocumentoResponseDto, Per08TipoDocumento>();
            CreateMap<TipoDocumentoRequestDto, Per08TipoDocumento>();

        }
    }
}
