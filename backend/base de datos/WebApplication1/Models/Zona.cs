using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Zona
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid? UsuarioId { get; set; }
}
