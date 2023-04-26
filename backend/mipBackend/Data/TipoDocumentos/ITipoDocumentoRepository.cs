using mipBackend.Models;
using mipBackend.Dtos.TipoDocumentoDtos;

namespace mipBackend.Data.TipoDocumentos
{
    public interface ITipoDocumentoRepository
    {

        Task<bool> SaveChanges();

        Task<IEnumerable<Per08TipoDocumento>> GetAllTipoDocumentos();

        Task<Per08TipoDocumento> GetTipoDocumentoById(int id);

        Task CreateTipoDocumento(Per08TipoDocumento TipoDocumento);

        Task UpdateTipoDocumento(Per08TipoDocumento TipoDocumento);

        Task DeleteTipoDocumento(int id);

        Task DisableTipoDocumento(int id);

        Task ActivateTipoDocumento(int id);

    }
}
