using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Prf05TipoAsignacionUsuario
{
    public decimal Prf05Llave { get; set; }

    public string? Prf05Nombre { get; set; }

    public string? Prf05Descripcion { get; set; }

    public int? Prf05Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Prf01Perfile> Prf01Perfiles { get; } = new List<Prf01Perfile>();
}
