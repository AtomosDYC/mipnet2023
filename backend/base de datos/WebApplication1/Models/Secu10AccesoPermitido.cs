using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Secu10AccesoPermitido
{
    public int Secu10Llave { get; set; }

    public Guid? Secu02Llave { get; set; }

    public Guid? Secu03Llave { get; set; }

    public bool? Activo { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public virtual Secu02Usuario? Secu02LlaveNavigation { get; set; }

    public virtual Secu03TipoAcceso? Secu03LlaveNavigation { get; set; }
}
