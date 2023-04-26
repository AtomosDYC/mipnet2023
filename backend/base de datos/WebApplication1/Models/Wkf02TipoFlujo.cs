using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Wkf02TipoFlujo
{
    public int Wkf02Llave { get; set; }

    public string? Wkf02Nombre { get; set; }

    public string? Wkf02Descripcion { get; set; }

    public int? Wkf02Orden { get; set; }

    public int? Wkf02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Wkf03Nivel> Wkf03Nivels { get; set; } = new List<Wkf03Nivel>();
}
