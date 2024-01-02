using mipBackend.Models;
using mipBackend.Dtos.NivelpermisoDtos;

namespace mipBackend.Data.Nivelpermisos
{
    public interface INivelpermisoRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<NivelpermisoResponseDto>> GetAllNivelpermisos();

        Task<wkf04Nivelpermiso> GetNivelpermisoById(int id);

        Task CreateNivelpermiso(wkf04Nivelpermiso region);

        Task UpdateNivelpermiso(wkf04Nivelpermiso region);

        Task DeleteNivelpermiso(int id);

        Task DisableNivelpermiso(int id);

        Task ActivateNivelpermiso(int id);

    }
}
