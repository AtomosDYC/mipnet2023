using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class esp10TipoRegla
{
    public int esp10llave { get; set; }

    public string? esp10nombre { get; set; }

    public string? esp10descripcion { get; set; }

    public int? esp10activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<esp11ReglaGrafico> esp11ReglaGraficos { get; } = new List<esp11ReglaGrafico>();
}
