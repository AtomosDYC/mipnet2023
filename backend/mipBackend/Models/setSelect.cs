using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mipBackend.Models
{
    public class setSelect
    {
        [Key]
        public int Value { get; set; }

        public string? Description { get; set; }
    }
}
