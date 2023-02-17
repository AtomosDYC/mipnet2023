using mipBackend.Models;
using mipBackend.Dtos.NivelFlujoDtos;

namespace mipBackend.Data.NivelFlujos
{
    public interface INivelFlujoRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<NivelFlujoResponseDto>> GetAllNivelFlujos();

        Task<Wkf03Nivel> GetNivelFlujoById(int id);

        Task CreateNivelFlujo(Wkf03Nivel nivelflujo);

        Task UpdateNivelFlujo(Wkf03Nivel nivelflujo);

        Task DeleteNivelFlujo(int id);

        Task DisableNivelFlujo(int id);

        Task ActivateNivelFlujo(int id);
    }
}
