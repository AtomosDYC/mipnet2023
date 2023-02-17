using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu10AccesoPermitido
{
    public int Secu10Llave { get; set; }

    public Guid? Secu02Llave { get; set; }

    public Guid? Secu03Llave { get; set; }

    public bool? Activo { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public virtual Secu02Usuario? Secu02LlaveNavigation { get; set; }

    public virtual Secu03TipoAcceso? Secu03LlaveNavigation { get; set; }
}
