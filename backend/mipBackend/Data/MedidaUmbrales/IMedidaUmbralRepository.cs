using mipBackend.Models;

namespace mipBackend.Data.MedidaUmbrales
{
    public interface IMedidaUmbralRepository
    {

        Task<bool> SaveChanges();

        Task<IEnumerable<Esp06MedidaUmbral>> GetAllMedidaUmbrales();

        Task<Esp06MedidaUmbral> GetMedidaUmbralById(int id);

        Task CreateMedidaUmbral(Esp06MedidaUmbral medidaumbral);

        Task UpdateMedidaUmbral(Esp06MedidaUmbral medidaumbral);

        Task DeleteMedidaUmbral(int id);

        Task DisableMedidaUmbral(int id);

        Task ActivateMedidaUmbral(int id);

    }
}
