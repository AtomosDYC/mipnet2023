using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu03TipoAcceso
{
    public Guid Secu03llave { get; set; }

    public string? Secu03nombre { get; set; }

    public string? Secu03descripcion { get; set; }

    public string? Secu03Info { get; set; }

    public bool? Secu03activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public virtual ICollection<Secu05UsuarioAcceso> Secu05UsuarioAccesos { get; } = new List<Secu05UsuarioAcceso>();

    public virtual ICollection<Secu10Accesopermitido> Secu10Accesopermitidos { get; } = new List<Secu10Accesopermitido>();
}
