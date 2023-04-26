using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Cnt07TipoSegmentacion
{
    public int Cnt07Llave { get; set; }

    public string? Cnt07Nombre { get; set; }

    public string? Cnt07Descripcion { get; set; }

    public int? Cnt18Llave { get; set; }

    public int? Cnt02Llave { get; set; }

    public int? Cnt07Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt08Segmentacion> Cnt08Segmentacions { get; set; } = new List<Cnt08Segmentacion>();

    public virtual Cnt18NivelSegmentacion? Cnt18LlaveNavigation { get; set; }
}
