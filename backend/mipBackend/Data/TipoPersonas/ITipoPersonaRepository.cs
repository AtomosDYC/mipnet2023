using mipBackend.Models;
using mipBackend.Dtos.TipopersonaDtos;

namespace mipBackend.Data.Tipopersonas
{
    public interface ITipopersonaRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<per03Tipopersona>> GetAllTipopersonas();

        Task<per03Tipopersona> GetTipopersonaById(int id);

        Task CreateTipopersona(per03Tipopersona Tipopersona);

        Task UpdateTipopersona(per03Tipopersona Tipopersona);

        Task DeleteTipopersona(int id);

        Task DisableTipopersona(int id);

        Task ActivateTipopersona(int id);


    }
}
