using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Wkf06Perfil
{
    public int wkf06llave { get; set; }

    public int? wkf01llave { get; set; }

    public string? wkf06nombre { get; set; }

    public string? wkf06descripcion { get; set; }

    public int? wkf06activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Prf04PlantillaPerfil> Prf04PlantillaPerfils { get; } = new List<Prf04PlantillaPerfil>();

    public virtual ICollection<Prf06PermisosUsuario> Prf06PermisosUsuarios { get; } = new List<Prf06PermisosUsuario>();

    public virtual Wkf01Flujo? Wkf01LlaveNavigation { get; set; }

    public virtual ICollection<Wkf07PerfilesPermiso> Wkf07PerfilesPermisos { get; } = new List<Wkf07PerfilesPermiso>();
}
