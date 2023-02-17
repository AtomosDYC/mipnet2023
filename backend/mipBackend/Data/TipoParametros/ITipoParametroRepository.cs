using mipBackend.Models;

namespace mipBackend.Data.TipoParametros
{
    public interface ITipoParametroRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Wkf10TipoParametro>> GetAllTipoParametros();

        Task<Wkf10TipoParametro> GetTipoParametroById(int id);

        Task CreateTipoParametro(Wkf10TipoParametro tipoparametro);

        Task UpdateTipoParametro(Wkf10TipoParametro tipoparametro);

        Task DeleteTipoParametro(int id);

        Task DisableTipoParametro(int id);

        Task ActivateTipoParametro(int id);
    }
}
