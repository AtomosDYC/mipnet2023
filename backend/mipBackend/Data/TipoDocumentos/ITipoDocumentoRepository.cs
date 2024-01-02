using mipBackend.Models;
using mipBackend.Dtos.TipoDocumentoDtos;

namespace mipBackend.Data.TipoDocumentos
{
    public interface ITipoDocumentoRepository
    {

        Task<bool> SaveChanges();

        Task<IEnumerable<per08TipoDocumento>> GetAllTipoDocumentos();

        Task<per08TipoDocumento> GetTipoDocumentoById(int id);

        Task CreateTipoDocumento(per08TipoDocumento TipoDocumento);

        Task UpdateTipoDocumento(per08TipoDocumento TipoDocumento);

        Task DeleteTipoDocumento(int id);

        Task DisableTipoDocumento(int id);

        Task ActivateTipoDocumento(int id);

    }
}
