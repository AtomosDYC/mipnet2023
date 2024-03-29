﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mipBackend.Models
{
    public class Inmueble
    {
        [Key]
        public int Id { get; set; }

        public string? nombre { get; set; }

        public string? Direccion { get; set; }

        [Required]
       // [Column(TypeName ="int(18,4)")]
        public int Precio { get; set; }

        public string? Picture { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public Guid? UsuarioId { get; set; }   

    }
}
