using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Wkf10TipoParametro
{
    public int wkf10llave { get; set; }

    public string? wkf10nombre { get; set; }

    public string? wkf10descripcion { get; set; }

    public int? wkf10activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Wkf09Parametro> Wkf09Parametros { get; } = new List<Wkf09Parametro>();
}
