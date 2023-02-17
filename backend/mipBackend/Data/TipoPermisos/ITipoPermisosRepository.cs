using mipBackend.Models;
using mipBackend.Dtos.TipoPermisoDtos;

namespace mipBackend.Data.TipoPermisos
{
    public interface ITipoPermisosRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Wkf05TipoPermiso>> GetAllTipoPermisos();

        Task<Wkf05TipoPermiso> GetTipoPermisoById(int id);

        Task CreateTipoPermiso(Wkf05TipoPermiso tipoflujo);

        Task UpdateTipoPermiso(Wkf05TipoPermiso tipoflujo);

        Task DeleteTipoPermiso(int id);

        Task DisableTipoPermiso(int id);

        Task ActivateTipoPermiso(int id);
    }
}
