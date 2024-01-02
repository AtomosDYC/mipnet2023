namespace mipBackend.Dtos.UsuarioDtos
{
    public class UserAuthReponseDto
    {

        public Guid? Id { get; set; }

        public string? Token { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }  
        
    }
}
