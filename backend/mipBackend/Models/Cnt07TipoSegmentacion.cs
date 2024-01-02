using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt07TipoSegmentacion
{
    public int cnt07llave { get; set; }

    public string? cnt07nombre { get; set; }

    public string? cnt07descripcion { get; set; }

    public int? cnt18llave { get; set; }

    public int? cnt02llave { get; set; }

    public int? cnt07activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<cnt08Segmentacion> cnt08Segmentacions { get; } = new List<cnt08Segmentacion>();

    public virtual cnt18NivelSegmentacion? cnt18llaveNavigation { get; set; }
}
