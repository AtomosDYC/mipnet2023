namespace mipBackend.Dtos.ClienteUsuarioDtos
{
    public class MenuClienteusuarioDto
    {
        public string? text { get; set; }
        public bool? selected { get; set; }
        public string? path { get; set; }
        public int? id { get; set; }
        public bool? disabled { get; set; }
        public int? parentId { get; set; }
    }
}
