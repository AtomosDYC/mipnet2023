using mipBackend.Models;
using mipBackend.Dtos.TipoCompersonaDtos;

namespace mipBackend.Data.TipoCompersonas
{
    public interface ITipoCompersonaRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<per04TipoComunicacion>> GetAllTipoCompersonas();

        Task<per04TipoComunicacion> GetTipoCompersonaById(int id);

        Task CreateTipoCompersona(per04TipoComunicacion tipocompersona);

        Task UpdateTipoCompersona(per04TipoComunicacion tipocompersona);

        Task DeleteTipoCompersona(int id);

        Task DisableTipoCompersona(int id);

        Task ActivateTipoCompersona(int id);
    }
}
