namespace mipBackend.Dtos.UsuarioDtos
{
    public class ResetPasswordResponseDto
    {
        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public string? Email { get; set; }

        public string? Token { get; set; }
    }
}
