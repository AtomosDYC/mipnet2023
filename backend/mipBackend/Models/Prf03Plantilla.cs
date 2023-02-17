using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Prf03Plantilla
{
    public int prf03llave { get; set; }

    public string? prf03nombre { get; set; }

    public string? prf03descripcion { get; set; }

    public int? prf03activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Prf04PlantillaPerfil> Prf04PlantillaPerfils { get; } = new List<Prf04PlantillaPerfil>();

    public virtual ICollection<Prf01Perfil> Prf01Llaves { get; } = new List<Prf01Perfil>();
}
