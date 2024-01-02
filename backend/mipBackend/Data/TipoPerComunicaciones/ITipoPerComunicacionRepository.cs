using mipBackend.Models;
using mipBackend.Dtos.TipoperComunicacionDtos;

namespace mipBackend.Data.TipoperComunicaciones
{
    public interface ITipoperComunicacionRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<TipoperComunicacionResponseDto>> GetAllTipoperComunicaciones();

        Task<IEnumerable<TipoperComunicacionResponseDto>> GetTipoperComunicacionById(int id);

        Task CreateTipoperComunicacion(per06TipopersonaComunicacion tipopercomunicacion);

        Task DeleteTipoperComunicacion(TipoperComunicacionRequestDto tipopercomunicacion);

  }
}
