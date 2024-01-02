using mipBackend.Models;
using mipBackend.Dtos.DefaultUserDtos;

namespace mipBackend.Data.DefaultUsers
{
    public interface IDefaultUserRepository 
    {

        Task<bool> SaveChanges();

        Task<DefaultUserResponseDto> GetAllDefaultUsers();

        Task<per09DefaultUser> GetDefaultUserById(int id);

        Task CreateDefaultUser(per09DefaultUser DefaultUser);

        Task UpdateDefaultUser(per09DefaultUser DefaultUser);

    }
}
