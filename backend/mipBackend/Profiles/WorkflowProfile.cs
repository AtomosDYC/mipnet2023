using AutoMapper;
using mipBackend.Dtos.WorkflowDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class WorkflowProfile : Profile
    {
        public WorkflowProfile()
        {

            CreateMap<wkf01Flujo, WorkflowResponseDto>();
            CreateMap<WorkflowResponseDto, wkf01Flujo>();
            CreateMap<WorkflowRequestDto, wkf01Flujo>();
            CreateMap<WorkflowNodopadreRequestDto, wkf01Flujo>();
            CreateMap<WorkflowConfiguracionwebDto, wkf01Flujo>();

        }
    }
}
