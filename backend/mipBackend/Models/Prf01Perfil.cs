using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Prf01Perfil
{
    public int Prf01Llave { get; set; }

    public int? Prf05Llave { get; set; }

    public Guid? Secu02Llave { get; set; }

    public int? Prf01Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Prf05TipoAsignacionUsuario? Prf05LlaveNavigation { get; set; }

    public virtual ICollection<Prf06PermisosUsuario> Prf06PermisosUsuarios { get; } = new List<Prf06PermisosUsuario>();

    public virtual Secu02Usuario? Secu02LlaveNavigation { get; set; }

    public virtual ICollection<Prf03Plantilla> Prf03Llaves { get; } = new List<Prf03Plantilla>();
}
