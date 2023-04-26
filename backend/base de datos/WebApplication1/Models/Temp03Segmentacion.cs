using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Temp03Segmentacion
{
    public int Temp03Llave { get; set; }

    public string? Temp03Nombre { get; set; }

    public string? Temp03Descripcion { get; set; }

    public int? Temp03NumeroMeses { get; set; }

    public int? Temp03NumeroSegmentosTotal { get; set; }

    public int? Temp03Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Temp01Temporadum> Temp01Temporada { get; set; } = new List<Temp01Temporadum>();
}
