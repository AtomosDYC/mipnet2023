using mipBackend.Dtos.MenuDtos;

namespace mipBackend.Data.Menus
{
    public interface IMenuRepository
    {
        Task<IEnumerable<MenuResponseDto>> GetMenu();


    }
}
