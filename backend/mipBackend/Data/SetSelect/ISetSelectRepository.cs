using mipBackend.Models;
using mipBackend.Dtos.SetSelectDtos;

namespace mipBackend.Data.SetSelect
{
    public interface ISetSelectRepository
    {
        Task<IEnumerable<setSelect>> GetAllSelect(SetSelectRequestDto request);
    }
}
