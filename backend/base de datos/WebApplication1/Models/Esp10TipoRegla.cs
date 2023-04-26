using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Esp10TipoRegla
{
    public int Esp10Llave { get; set; }

    public string? Esp10Nombre { get; set; }

    public string? Esp10Descripcion { get; set; }

    public int? Esp10Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Esp11ReglaGrafico> Esp11ReglaGraficos { get; set; } = new List<Esp11ReglaGrafico>();
}
