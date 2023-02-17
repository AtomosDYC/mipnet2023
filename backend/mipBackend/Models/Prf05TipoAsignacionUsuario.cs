using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Prf05TipoAsignacionUsuario
{
    public int Prf05Llave { get; set; }

    public string? Prf05Nombre { get; set; }

    public string? Prf05Descripcion { get; set; }

    public int? Prf05Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Prf01Perfil> Prf01Perfiles { get; } = new List<Prf01Perfil>();
}
