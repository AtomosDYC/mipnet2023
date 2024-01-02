using AutoMapper;
using mipBackend.Dtos.TipoDocumentoDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class TipoDocumentoProfile : Profile
    {
        public TipoDocumentoProfile()
        {

            CreateMap<per08TipoDocumento, TipoDocumentoResponseDto>();
            CreateMap<TipoDocumentoResponseDto, per08TipoDocumento>();
            CreateMap<TipoDocumentoRequestDto, per08TipoDocumento>();

        }
    }
}
