using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Prf06PermisosUsuario
{
    public int Prf01Llave { get; set; }

    public int Wkf06Llave { get; set; }

    public int? Prf06Activo { get; set; }

    public virtual Wkf06Perfile Wkf06LlaveNavigation { get; set; } = null!;
}
