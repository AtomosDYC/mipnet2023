using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu06UsuarioRol
{
    public Guid Secu01llave { get; set; }

    public string userid { get; set; } = null!;

    public bool? Secu06activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public virtual Secu01Rol Secu01LlaveNavigation { get; set; } = null!;

    public virtual Secu02Usuario useridNavigation { get; set; } = null!;
}
