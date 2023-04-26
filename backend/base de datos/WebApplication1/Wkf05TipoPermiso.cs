using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Wkf05TipoPermiso
{
    public int Wkf05Llave { get; set; }

    public string? Wkf05Nombre { get; set; }

    public string? Wkf05Descripcion { get; set; }

    public string? Wkf05Sigla { get; set; }

    public int? Wkf05Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Wkf04NivelPermiso> Wkf04NivelPermisos { get; set; } = new List<Wkf04NivelPermiso>();

    public virtual ICollection<Wkf07PerfilesPermiso> Wkf07PerfilesPermisos { get; set; } = new List<Wkf07PerfilesPermiso>();
}
