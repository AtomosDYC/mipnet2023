using mipBackend.Models;    

namespace mipBackend.Data.Plantillas
{
    public interface IPlantillaRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Prf03Plantilla>> GetAllPlantillas();

        Task<Prf03Plantilla> GetPlantillaById(int id);

        Task CreatePlantilla(Prf03Plantilla plantilla);

        Task UpdatePlantilla(Prf03Plantilla plantilla);

        Task DeletePlantilla(int id);

        Task DisablePlantilla(int id);

        Task ActivatePlantilla(int id);
    }
}
