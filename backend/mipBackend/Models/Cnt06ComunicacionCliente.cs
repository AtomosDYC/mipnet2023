using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt06ComunicacionCliente
{
    public int cnt06llave { get; set; }

    public int? cnt01llave { get; set; }

    public int? cnt08llave { get; set; }

    public int? cnt10llave { get; set; }

    public string? cnt06Direccion { get; set; }

    public int? sist03llave { get; set; }

    public string? cnt06Casilla { get; set; }

    public int? cnt06TieneCasilla { get; set; }

    public string? cnt06CodigoPostal { get; set; }

    public string? cnt06Email { get; set; }

    public int? cnt06TipoMail { get; set; }

    public string? cnt06Telefono1 { get; set; }

    public string? cnt06Telefono2 { get; set; }

    public string? cnt06Celular1 { get; set; }

    public string? cnt06Celular2 { get; set; }

    public string? cnt06Fax { get; set; }

    public string? cnt06SitioWeb { get; set; }

    public int? cnt06activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual cnt01CuentaCliente cnt01llaveNavigation { get; set; } = null!;

    public virtual cnt08Segmentacion? cnt08llaveNavigation { get; set; }

    public virtual cnt10TipoComunicacion cnt10llaveNavigation { get; set; } = null!;

    public virtual sist03Comuna? sist03llaveNavigation { get; set; }
}
