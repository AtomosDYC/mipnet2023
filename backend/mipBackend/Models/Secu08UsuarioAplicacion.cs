using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu08UsuarioAplicacion
{
    public Guid userid { get; set; }

    public Guid Secu07llave { get; set; }

    public string? Secu08Info { get; set; }

    public string? Secu08Observacion { get; set; }

    public bool? Secu08activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public virtual Secu02Usuario useridNavigation { get; set; } = null!;

    public virtual Secu07Aplicacion Secu07llaveNavigation { get; set; } = null!;
}
