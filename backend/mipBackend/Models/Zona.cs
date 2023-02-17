﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mipBackend.Models
{
    public class Zona
    {
        [Key]
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool ? isDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public Guid? UsuarioId { get; set; }
    }
}
