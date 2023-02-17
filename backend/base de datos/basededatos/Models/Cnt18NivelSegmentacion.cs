using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt18NivelSegmentacion
{
    public decimal Cnt18Llave { get; set; }

    public string? Cnt18Nombre { get; set; }

    public string Cnt18Descripccion { get; set; } = null!;

    public int? Cnt18NivelCapa { get; set; }

    public int? Cnt18Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt07TipoSegmentacion> Cnt07TipoSegmentacions { get; } = new List<Cnt07TipoSegmentacion>();
}
