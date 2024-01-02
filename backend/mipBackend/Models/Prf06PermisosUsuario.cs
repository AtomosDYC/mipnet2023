using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class prf06permisosUsuario
{
    public int prf01llave { get; set; }

    public int wkf06llave { get; set; }

    public int? prf06activo { get; set; }

    public virtual prf01perfil prf01llaveNavigation { get; set; } = null!;

    public virtual wkf06perfil wkf06llaveNavigation { get; set; } = null!;
}
