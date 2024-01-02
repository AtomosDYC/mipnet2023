using mipBackend.Models;
using mipBackend.Dtos.WorkflowParametrosDtos;

namespace mipBackend.Data.WorkflowParametros
{
    public interface IWorkflowParametroRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<WorkflowParametroResponseDto>> GetAllWorkflowParametros(int id);

        Task CreateWorkflowParametro(wkf09Parametro workflowparametro);

        Task<wkf09Parametro> GetWorkflowParametroById(int id);

        Task DeleteWorkflowParametro(int id);

    }
}
