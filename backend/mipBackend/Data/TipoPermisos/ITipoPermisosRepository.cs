using mipBackend.Models;
using mipBackend.Dtos.TipopermisoDtos;

namespace mipBackend.Data.Tipopermisos
{
    public interface ITipopermisosRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<wkf05Tipopermiso>> GetAllTipopermisos();

        Task<wkf05Tipopermiso> GetTipopermisoById(int id);

        Task CreateTipopermiso(wkf05Tipopermiso tipoflujo);

        Task UpdateTipopermiso(wkf05Tipopermiso tipoflujo);

        Task DeleteTipopermiso(int id);

        Task DisableTipopermiso(int id);

        Task ActivateTipopermiso(int id);
    }
}
