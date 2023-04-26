using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Cnt21TipoEstacion
{
    public int Cnt21Llave { get; set; }

    public string? Cnt21Nombre { get; set; }

    public string? Cnt21Descripcion { get; set; }

    public int? Cnt21Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt22EstacionTipoEstacion> Cnt22EstacionTipoEstacions { get; set; } = new List<Cnt22EstacionTipoEstacion>();
}
