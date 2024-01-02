using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class prf05TipoAsignacionUsuario
{
    public int prf05llave { get; set; }

    public string? prf05nombre { get; set; }

    public string? prf05descripcion { get; set; }

    public int? prf05activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<prf01perfil> prf01perfiles { get; } = new List<prf01perfil>();
}
