namespace mipBackend.Dtos.UsuarioDtos
{
    public class UsuarioLoginResponseDto
    {
        public Guid? Id { get; set; }

        public string? Token { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? roleid { get; set; }

        public string? rolename { get; set; }

        public int? per01llave { get; set; }

        public string? per01nombre { get; set; }

        public int? prf03llave { get; set; }

        public string? prf03nombre { get; set; }
    }
}
