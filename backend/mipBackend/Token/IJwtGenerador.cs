using mipBackend.Models;

namespace mipBackend.Token
{
    public interface IJwtGenerador
    {
        string CrearToken(Usuario usuario);
    }
}
