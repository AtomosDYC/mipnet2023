using mipBackend.Models;
using mipBackend.Dtos.NivelFlujoDtos;

namespace mipBackend.Data.NivelFlujos
{
    public interface INivelFlujoRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<NivelFlujoResponseDto>> GetAllNivelFlujos();

        Task<wkf03Nivel> GetNivelFlujoById(int id);

        Task CreateNivelFlujo(wkf03Nivel nivelflujo);

        Task UpdateNivelFlujo(wkf03Nivel nivelflujo);

        Task DeleteNivelFlujo(int id);

        Task DisableNivelFlujo(int id);

        Task ActivateNivelFlujo(int id);
    }
}
