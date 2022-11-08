using System.Security.Claims;

namespace mipBackend.Token
{
    public class UsuarioSesion : IUsuarioSesion
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UsuarioSesion(IHttpContextAccessor httpContextAccessor) {
        
            _contextAccessor = httpContextAccessor;

        }
        public string ObtenerUsuarioSesion()
        {
            var userName = _contextAccessor.HttpContext!.User?.Claims?
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            return userName ?? string.Empty;

        }
    }
}
