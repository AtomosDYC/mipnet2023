using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Wkf02TipoFlujo
{
    public decimal Wkf02Llave { get; set; }

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

    public virtual ICollection<Wkf03Nivel> Wkf03Nivels { get; } = new List<Wkf03Nivel>();
}
