using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu10Accesopermitido
{
    public int Secu10llave { get; set; }

    public Guid? userid { get; set; }

    public Guid? Secu03llave { get; set; }

    public bool? activo { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public virtual Secu02Usuario? useridNavigation { get; set; }

    public virtual Secu03TipoAcceso? Secu03llaveNavigation { get; set; }
}
