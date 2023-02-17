using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt07TipoSegmentacion
{
    public decimal Cnt07Llave { get; set; }

    public string? Cnt07Nombre { get; set; }

    public string? Cnt07Descripcion { get; set; }

    public decimal? Cnt18Llave { get; set; }

    public decimal? Cnt02Llave { get; set; }

    public int? Cnt07Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt08Segmentacion> Cnt08Segmentacions { get; } = new List<Cnt08Segmentacion>();

    public virtual Cnt18NivelSegmentacion? Cnt18LlaveNavigation { get; set; }
}
