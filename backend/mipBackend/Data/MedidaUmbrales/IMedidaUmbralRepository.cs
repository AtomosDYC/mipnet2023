using mipBackend.Models;

namespace mipBackend.Data.MedidaUmbrales
{
    public interface IMedidaUmbralRepository
    {

        Task<bool> SaveChanges();

        Task<IEnumerable<esp06MedidaUmbral>> GetAllMedidaUmbrales();

        Task<esp06MedidaUmbral> GetMedidaUmbralById(int id);

        Task CreateMedidaUmbral(esp06MedidaUmbral medidaumbral);

        Task UpdateMedidaUmbral(esp06MedidaUmbral medidaumbral);

        Task DeleteMedidaUmbral(int id);

        Task DisableMedidaUmbral(int id);

        Task ActivateMedidaUmbral(int id);

    }
}
