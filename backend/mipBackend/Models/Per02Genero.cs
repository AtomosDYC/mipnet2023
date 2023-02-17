using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Per02Genero
{
    public int Per02Llave { get; set; }

    public string? Per02Titulo { get; set; }

    public string? Per02Genero1 { get; set; }

    public string? Per02Sexo { get; set; }

    public int? Per02Orden { get; set; }

    public int? Per02Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Per01Persona> Per01Personas { get; } = new List<Per01Persona>();

    public virtual ICollection<Sist08ContactoUsuario> Sist08ContactoUsuarios { get; } = new List<Sist08ContactoUsuario>();
}
