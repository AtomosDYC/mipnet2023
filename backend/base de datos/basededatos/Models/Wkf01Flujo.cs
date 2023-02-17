using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Wkf01Flujo
{
    public decimal Wkf01Llave { get; set; }

    public string? Wkf01Nombre { get; set; }

    public string? Wkf01Descripcion { get; set; }

    public decimal? Wkf01LlavePadre { get; set; }

    public decimal? Wkf03Llave { get; set; }

    public int? Wkf01EsInicio { get; set; }

    public decimal? Wkf01Orden { get; set; }

    public decimal? Wkf01Prioridad { get; set; }

    public int Wkf01Activo { get; set; }

    public string? Wkf01Directorio { get; set; }

    public string? Wkf01Url { get; set; }

    public string? Wkf01IconoUrl { get; set; }

    public int? Wkf01VisibleMenu { get; set; }

    public string? Wkf01ImagenGrande { get; set; }

    public string? Wkf01ImagenPequena { get; set; }

    public string Wkf01EstadoRegistro { get; set; } = null!;

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Wkf03Nivel? Wkf03LlaveNavigation { get; set; }

    public virtual ICollection<Wkf06Perfile> Wkf06Perfiles { get; } = new List<Wkf06Perfile>();

    public virtual ICollection<Wkf09Parametro> Wkf09Parametros { get; } = new List<Wkf09Parametro>();
}
