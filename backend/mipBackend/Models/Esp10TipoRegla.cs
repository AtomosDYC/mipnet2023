using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Esp10TipoRegla
{
    public int Esp10Llave { get; set; }

    public string? Esp10Nombre { get; set; }

    public string? Esp10Descripcion { get; set; }

    public int? Esp10Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Esp11ReglaGrafico> Esp11ReglaGraficos { get; } = new List<Esp11ReglaGrafico>();
}
