using mipBackend.Models;
using mipBackend.Dtos.TemporadaDtos;

namespace mipBackend.Data.Temporada
{
    public interface ISegmentarTemporadaRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Temp03Segmentacion>> GetAllSegmentarTemporada();

        Task<Temp03Segmentacion> GetSegmentarTemporadaById(int id);

        Task CreateSegmentarTemporada(Temp03Segmentacion Tipopersona);

        Task UpdateSegmentarTemporada(Temp03Segmentacion Tipopersona);

        Task DeleteSegmentarTemporada(int id);

        Task DisableSegmentarTemporada(int id);

        Task ActivateSegmentarTemporada(int id);

    }
}
