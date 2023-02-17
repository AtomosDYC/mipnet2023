using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu08UsuarioAplicacion
{
    public Guid Secu02Llave { get; set; }

    public Guid Secu07Llave { get; set; }

    public string? Secu08Info { get; set; }

    public string? Secu08Observacion { get; set; }

    public bool? Secu08Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public virtual Secu02Usuario Secu02LlaveNavigation { get; set; } = null!;

    public virtual Secu07Aplicacion Secu07LlaveNavigation { get; set; } = null!;
}
