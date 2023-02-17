using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt09ComunicacionSegmentacion
{
    public int Cnt09Llave { get; set; }

    public int? Cnt08Llave { get; set; }

    public int? Cnt10Llave { get; set; }

    public string? Cnt09Direccion { get; set; }

    public int? Sist03Llave { get; set; }

    public string? Cnt09Casilla { get; set; }

    public int? Cnt09SinCasilla { get; set; }

    public string? Cnt09CodigoPostal { get; set; }

    public string? Cnt09Email { get; set; }

    public int? Cnt09TipoMail { get; set; }

    public string? Cnt09Telefono1 { get; set; }

    public string? Cnt09Telefono2 { get; set; }

    public string? Cnt09Celular1 { get; set; }

    public string? Cnt09Celular2 { get; set; }

    public string? Cnt09Fax { get; set; }

    public string? Cnt09SitioWeb { get; set; }

    public int? Cnt09Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Cnt08Segmentacion Cnt08LlaveNavigation { get; set; } = null!;
}
