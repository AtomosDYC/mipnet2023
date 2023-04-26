using mipBackend.Models;
using mipBackend.Dtos.DefaultUserDtos;

namespace mipBackend.Data.DefaultUsers
{
    public interface IDefaultUserRepository 
    {

        Task<bool> SaveChanges();

        Task<DefaultUserResponseDto> GetAllDefaultUsers();

        Task<Per09DefaultUser> GetDefaultUserById(int id);

        Task CreateDefaultUser(Per09DefaultUser DefaultUser);

        Task UpdateDefaultUser(Per09DefaultUser DefaultUser);

    }
}
