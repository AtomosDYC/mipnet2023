using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Prf03Plantilla
{
    public decimal Prf03Llave { get; set; }

    public string? Prf03Nombre { get; set; }

    public string? Prf03Descripcion { get; set; }

    public string? Prf03EstadoRegistro { get; set; }

    public int? Prf03Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Prf04PlantillaPerfil> Prf04PlantillaPerfils { get; } = new List<Prf04PlantillaPerfil>();

    public virtual ICollection<Prf01Perfile> Prf01Llaves { get; } = new List<Prf01Perfile>();
}
