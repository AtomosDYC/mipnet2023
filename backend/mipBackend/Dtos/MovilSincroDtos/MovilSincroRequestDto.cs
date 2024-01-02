namespace mipBackend.Dtos.MovilSincroDtos
{
    public class MovilSincroRequestDto
    {

        public string? nombre_tabla { get; set; }

        public DateTime? fecha_consulta { get; set; }

        public Guid? llave_usuario { get; set; }

        public int? llave_periodo { get; set; }

    }
}
