using mipBackend.Models;
using mipBackend.Dtos.WorkflowDtos;

namespace mipBackend.Data.Workflows
{
    public interface IWorkflowRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<WorkflowResponseDto>> GetAllWorkflow();

        Task<WorkflowResponseDto> GetWorkflowById(int id);

        Task CreateDatosgenerales(wkf01Flujo workflow);

        Task UpdateDatosgenerales(wkf01Flujo workflow);

        Task UpdateNodopadre(wkf01Flujo workflow);

        Task UpdateConfiguracionWeb(wkf01Flujo workflow);

        Task<WorkflowResponseDto> GetWorkflowNodopadreById(int id);


    }
}
