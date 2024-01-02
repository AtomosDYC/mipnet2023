using mipBackend.Models;    

namespace mipBackend.Data.Plantillas
{
    public interface IPlantillaRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<prf03Plantilla>> GetAllPlantillas();

        Task<prf03Plantilla> GetPlantillaById(int id);

        Task CreatePlantilla(prf03Plantilla plantilla);

        Task UpdatePlantilla(prf03Plantilla plantilla);

        Task DeletePlantilla(int id);

        Task DisablePlantilla(int id);

        Task ActivatePlantilla(int id);
    }
}
