namespace mipBackend.Dtos.InmuebleDtos
{
    public class InmuebleResponseDto
    {

        public int Id { get; set; }
        public string? nombre { get; set; }

        public string? Direccion { get; set; }

        public int Precio { get; set; }

        public string? Picture { get; set; }

        public DateTime? FechaCreacion { get; set; }

    }
}
