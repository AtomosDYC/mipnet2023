using AutoMapper;
using mipBackend.Dtos.WorkflowDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class WorkflowProfile : Profile
    {
        public WorkflowProfile()
        {

            CreateMap<Wkf01Flujo, WorkflowResponseDto>();
            CreateMap<WorkflowResponseDto, Wkf01Flujo>();
            CreateMap<WorkflowRequestDto, Wkf01Flujo>();
            CreateMap<WorkflowNodopadreRequestDto, Wkf01Flujo>();
            CreateMap<WorkflowConfiguracionwebDto, Wkf01Flujo>();

        }
    }
}
