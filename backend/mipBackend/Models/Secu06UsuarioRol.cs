using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu06UsuarioRol
{
    public Guid Secu01Llave { get; set; }

    public Guid Secu02Llave { get; set; }

    public bool? Secu06Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public virtual Secu01Rol Secu01LlaveNavigation { get; set; } = null!;

    public virtual Secu02Usuario Secu02LlaveNavigation { get; set; } = null!;
}
