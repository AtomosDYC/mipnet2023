using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Secu06UsuarioRol
{
    public Guid Secu01Llave { get; set; }

    public string Secu02Llave { get; set; } = null!;

    public bool? Secu06Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public virtual Secu01Rol Secu01LlaveNavigation { get; set; } = null!;

    public virtual Secu02Usuario Secu02LlaveNavigation { get; set; } = null!;
}
