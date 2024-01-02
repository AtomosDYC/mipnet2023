using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt18NivelSegmentacion
{
    public int cnt18llave { get; set; }

    public string? cnt18nombre { get; set; }

    public string? cnt18Descripccion { get; set; } = null!;

    public int? cnt18NivelCapa { get; set; }

    public int? cnt18activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<cnt07TipoSegmentacion> cnt07TipoSegmentacions { get; } = new List<cnt07TipoSegmentacion>();
}
