using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Prf06PermisosUsuario
{
    public int Prf01Llave { get; set; }

    public int Wkf06Llave { get; set; }

    public int? Prf06Activo { get; set; }

    public virtual Prf01Perfile Prf01LlaveNavigation { get; set; } = null!;

    public virtual Wkf06Perfile Wkf06LlaveNavigation { get; set; } = null!;
}
