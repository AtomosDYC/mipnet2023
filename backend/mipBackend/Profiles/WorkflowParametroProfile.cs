using AutoMapper;
using mipBackend.Dtos.WorkflowParametrosDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class WorkflowParametroProfile : Profile
    {

        public WorkflowParametroProfile()
        {

            CreateMap<Wkf09Parametro, WorkflowParametroResponseDto>();
            CreateMap<WorkflowParametroResponseDto, Wkf09Parametro>();
            CreateMap<WorkflowParametroRequestDto, Wkf09Parametro>();

        }

    }
}
