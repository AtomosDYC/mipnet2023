using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Wkf09Parametro
{
    public int Wkf09Llave { get; set; }

    public int? Wkf01Llave { get; set; }

    public int? Wkf10Llave { get; set; }

    public string? Wkf09Variable { get; set; }

    public string? Wkf09Valor { get; set; }

    public int? Wkf09Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Wkf01Flujo? Wkf01LlaveNavigation { get; set; }

    public virtual Wkf10TipoParametro? Wkf10LlaveNavigation { get; set; }
}
