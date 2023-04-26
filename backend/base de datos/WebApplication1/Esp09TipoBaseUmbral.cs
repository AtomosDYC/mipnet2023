using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Esp09TipoBaseUmbral
{
    public int Esp09Llave { get; set; }

    public string? Esp09Nombre { get; set; }

    public string? Esp09Descripcion { get; set; }

    public int? Esp09Activo { get; set; }

    public int? Esp09Orden { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Esp05Umbral> Esp05Umbrals { get; set; } = new List<Esp05Umbral>();
}
