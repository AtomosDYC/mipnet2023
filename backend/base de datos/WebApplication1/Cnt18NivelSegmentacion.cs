using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Cnt18NivelSegmentacion
{
    public int Cnt18Llave { get; set; }

    public string? Cnt18Nombre { get; set; }

    public string? Cnt18Descripccion { get; set; }

    public int? Cnt18NivelCapa { get; set; }

    public int? Cnt18Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt07TipoSegmentacion> Cnt07TipoSegmentacions { get; set; } = new List<Cnt07TipoSegmentacion>();
}
