using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Wkf06Perfile
{
    public decimal Wkf06Llave { get; set; }

    public decimal? Wkf01Llave { get; set; }

    public string? Wkf06Nombre { get; set; }

    public string? Wkf06Descripcion { get; set; }

    public int? Wkf06Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Prf04PlantillaPerfil> Prf04PlantillaPerfils { get; } = new List<Prf04PlantillaPerfil>();

    public virtual ICollection<Prf06PermisosUsuario> Prf06PermisosUsuarios { get; } = new List<Prf06PermisosUsuario>();

    public virtual Wkf01Flujo? Wkf01LlaveNavigation { get; set; }

    public virtual ICollection<Wkf07PerfilesPermiso> Wkf07PerfilesPermisos { get; } = new List<Wkf07PerfilesPermiso>();
}
