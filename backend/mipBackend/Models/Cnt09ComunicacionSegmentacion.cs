using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt09ComunicacionSegmentacion
{
    public int cnt09llave { get; set; }

    public int? cnt08llave { get; set; }

    public int? cnt10llave { get; set; }

    public string? cnt09Direccion { get; set; }

    public int? sist03llave { get; set; }

    public string? cnt09Casilla { get; set; }

    public int? cnt09SinCasilla { get; set; }

    public string? cnt09CodigoPostal { get; set; }

    public string? cnt09Email { get; set; }

    public int? cnt09TipoMail { get; set; }

    public string? cnt09Telefono1 { get; set; }

    public string? cnt09Telefono2 { get; set; }

    public string? cnt09Celular1 { get; set; }

    public string? cnt09Celular2 { get; set; }

    public string? cnt09Fax { get; set; }

    public string? cnt09SitioWeb { get; set; }

    public int? cnt09activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual cnt08Segmentacion cnt08llaveNavigation { get; set; } = null!;
}
