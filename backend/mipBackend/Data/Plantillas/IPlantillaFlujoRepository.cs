using mipBackend.Models;
using mipBackend.Dtos.PlantillaFlujoDtos;

namespace mipBackend.Data.Plantillas
{
    public interface IPlantillaFlujoRepository
    {
        Task<bool> SaveChanges();

        Task CreatePlantilla(Prf04PlantillaFlujo plantilla);

        Task<IEnumerable<PlantillaFlujoResponseDto>> GetAllPlantillaFlujos();


    }
}
