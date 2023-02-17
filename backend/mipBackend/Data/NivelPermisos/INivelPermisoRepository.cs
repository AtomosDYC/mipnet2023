using mipBackend.Models;
using mipBackend.Dtos.NivelPermisoDtos;

namespace mipBackend.Data.NivelPermisos
{
    public interface INivelPermisoRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<NivelPermisoResponseDto>> GetAllNivelPermisos();

        Task<Wkf04NivelPermiso> GetNivelPermisoById(int id);

        Task CreateNivelPermiso(Wkf04NivelPermiso region);

        Task UpdateNivelPermiso(Wkf04NivelPermiso region);

        Task DeleteNivelPermiso(int id);

        Task DisableNivelPermiso(int id);

        Task ActivateNivelPermiso(int id);

    }
}
