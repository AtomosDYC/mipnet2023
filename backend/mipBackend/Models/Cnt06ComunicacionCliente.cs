using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt06ComunicacionCliente
{
    public int Cnt06Llave { get; set; }

    public int? Cnt01Llave { get; set; }

    public int? Cnt08Llave { get; set; }

    public int? Cnt10Llave { get; set; }

    public string? Cnt06Direccion { get; set; }

    public int? Sist03Llave { get; set; }

    public string? Cnt06Casilla { get; set; }

    public int? Cnt06TieneCasilla { get; set; }

    public string? Cnt06CodigoPostal { get; set; }

    public string? Cnt06Email { get; set; }

    public int? Cnt06TipoMail { get; set; }

    public string? Cnt06Telefono1 { get; set; }

    public string? Cnt06Telefono2 { get; set; }

    public string? Cnt06Celular1 { get; set; }

    public string? Cnt06Celular2 { get; set; }

    public string? Cnt06Fax { get; set; }

    public string? Cnt06SitioWeb { get; set; }

    public int? Cnt06Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Cnt01CuentaCliente Cnt01LlaveNavigation { get; set; } = null!;

    public virtual Cnt08Segmentacion? Cnt08LlaveNavigation { get; set; }

    public virtual Cnt10TipoComunicacion Cnt10LlaveNavigation { get; set; } = null!;

    public virtual Sist03Comuna? Sist03LlaveNavigation { get; set; }
}
