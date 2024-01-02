namespace mipBackend.Dtos.MenuDtos
{
    public class MenuResponseDto
    {

        public string? text { get; set; }

        public string? path { get; set; }

        public bool? selected { get; set; }

        public int? id { get; set; }

        public string? icon { get; set; }

        public int? parentId { get; set; } = null;


    }
}
