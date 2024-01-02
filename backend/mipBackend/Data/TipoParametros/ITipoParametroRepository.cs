using mipBackend.Models;

namespace mipBackend.Data.TipoParametros
{
    public interface ITipoParametroRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<wkf10TipoParametro>> GetAllTipoParametros();

        Task<wkf10TipoParametro> GetTipoParametroById(int id);

        Task CreateTipoParametro(wkf10TipoParametro tipoparametro);

        Task UpdateTipoParametro(wkf10TipoParametro tipoparametro);

        Task DeleteTipoParametro(int id);

        Task DisableTipoParametro(int id);

        Task ActivateTipoParametro(int id);
    }
}
