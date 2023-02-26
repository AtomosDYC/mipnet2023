using mipBackend.Models;
using mipBackend.Dtos.TipoPerComunicacionDtos;

namespace mipBackend.Data.TipoPerComunicaciones
{
    public interface ITipoPerComunicacionRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<TipoPerComunicacionResponseDto>> GetAllTipoPerComunicaciones();

        Task<IEnumerable<TipoPerComunicacionResponseDto>> GetTipoPerComunicacionById(int id);

        Task CreateTipoPerComunicacion(Per06TipoPersonaComunicacion tipopercomunicacion);

        Task DeleteTipoPerComunicacion(TipoPerComunicacionRequestDto tipopercomunicacion);

  }
}
