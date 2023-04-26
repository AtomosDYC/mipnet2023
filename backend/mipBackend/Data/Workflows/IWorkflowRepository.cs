using mipBackend.Models;
using mipBackend.Dtos.WorkflowDtos;

namespace mipBackend.Data.Workflows
{
    public interface IWorkflowRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<WorkflowResponseDto>> GetAllWorkflow();

        Task<WorkflowResponseDto> GetWorkflowById(int id);

        Task CreateDatosgenerales(Wkf01Flujo workflow);

        Task UpdateDatosgenerales(Wkf01Flujo workflow);

        Task UpdateNodopadre(Wkf01Flujo workflow);

        Task UpdateConfiguracionWeb(Wkf01Flujo workflow);

        Task<WorkflowResponseDto> GetWorkflowNodopadreById(int id);


    }
}
