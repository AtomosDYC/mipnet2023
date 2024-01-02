namespace mipBackend.Dtos.UsuarioDtos
{
    public class UsuarioRegistroResponseDto
    {
        public Guid? userid { get; set; }

        public string? username { get; set; }

        public string? email { get; set; }

        public bool? emailconfirmed { get; set; }

        public Guid? roleid { get; set; }
        
        public string? rolename { get; set; }

        public int? per01llave { get; set; }

        public string? per01nombre { get; set; }

        public int? tipodocumentoid { get; set; }

        public string? tipodocumentonombre { get; set; }

        public int? tipopersonaid { get; set; }

        public string? tipopersonanombre { get; set; }

        public int? plantillaid { get; set; }

        public string? plantillanombre { get; set; }

        public int? saludoid { get; set; }

        public string? saludonombre { get; set; } 

    }
}
