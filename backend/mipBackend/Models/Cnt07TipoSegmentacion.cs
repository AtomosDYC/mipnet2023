using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt07TipoSegmentacion
{
    public int Cnt07Llave { get; set; }

    public string? Cnt07Nombre { get; set; }

    public string? Cnt07Descripcion { get; set; }

    public int? Cnt18Llave { get; set; }

    public int? Cnt02Llave { get; set; }

    public int? Cnt07Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Cnt08Segmentacion> Cnt08Segmentacions { get; } = new List<Cnt08Segmentacion>();

    public virtual Cnt18NivelSegmentacion? Cnt18LlaveNavigation { get; set; }
}
