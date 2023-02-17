using mipBackend.Dtos.RolDtos;
using mipBackend.Models;
using Microsoft.AspNetCore.Identity;

namespace mipBackend.Data.Roles
{
    public interface IRolesRepository
    {
  
        Task<IEnumerable<IdentityRole>> GetAllRoles();

    }
}
