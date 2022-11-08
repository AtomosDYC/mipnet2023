using Microsoft.AspNetCore.Identity;

namespace mipBackend.Models
{
    public class Usuario: IdentityUser
    {
        public string? Nombre { get; set; }

        public string? apellido { get; set; }

        public string? Telefono { get; set; }

    }
}
