using AutoMapper;
using mipBackend.Dtos.WorkflowParametrosDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class WorkflowParametroProfile : Profile
    {

        public WorkflowParametroProfile()
        {

            CreateMap<wkf09Parametro, WorkflowParametroResponseDto>();
            CreateMap<WorkflowParametroResponseDto, wkf09Parametro>();
            CreateMap<WorkflowParametroRequestDto, wkf09Parametro>();

        }

    }
}
