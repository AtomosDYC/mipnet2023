using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt18NivelSegmentacion
{
    public int Cnt18Llave { get; set; }

    public string? Cnt18Nombre { get; set; }

    public string? Cnt18Descripccion { get; set; } = null!;

    public int? Cnt18NivelCapa { get; set; }

    public int? Cnt18Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Cnt07TipoSegmentacion> Cnt07TipoSegmentacions { get; } = new List<Cnt07TipoSegmentacion>();
}
