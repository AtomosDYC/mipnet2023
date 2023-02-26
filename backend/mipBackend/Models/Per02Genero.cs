using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Per02Genero
{
    public int per02llave { get; set; }

    public string? per02titulo { get; set; }

    public int? per02orden { get; set; }

    public int? per02activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Per01Persona> Per01Personas { get; } = new List<Per01Persona>();

    public virtual ICollection<Sist08ContactoUsuario> Sist08ContactoUsuarios { get; } = new List<Sist08ContactoUsuario>();
}
