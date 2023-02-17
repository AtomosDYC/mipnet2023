using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Wkf05TipoPermiso
{
    public int wkf05llave { get; set; }

    public string? wkf05nombre { get; set; }

    public string? wkf05descripcion { get; set; }

    public string? wkf05sigla { get; set; }

    public int? wkf05activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Wkf04NivelPermiso> Wkf04NivelPermisos { get; } = new List<Wkf04NivelPermiso>();

    public virtual ICollection<Wkf07PerfilesPermiso> Wkf07PerfilesPermisos { get; } = new List<Wkf07PerfilesPermiso>();
}
