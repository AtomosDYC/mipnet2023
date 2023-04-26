using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Wkf10TipoParametro
{
    public int Wkf10Llave { get; set; }

    public string? Wkf10Nombre { get; set; }

    public string? Wkf10Descripcion { get; set; }

    public int? Wkf10Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Wkf09Parametro> Wkf09Parametros { get; set; } = new List<Wkf09Parametro>();
}
