using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt06ComunicacionCliente
{
    public int cnt06llave { get; set; }

    public int? cnt01llave { get; set; }

    public int? cnt08llave { get; set; }

    public int? cnt10llave { get; set; }

    public string? cnt06direccion { get; set; }

    public int? sist03llave { get; set; }

    public string? cnt06casilla { get; set; }

    public int? cnt06tienecasilla { get; set; }

    public string? cnt06codigopostal { get; set; }

    public string? cnt06email { get; set; }

    public int? cnt06tipomail { get; set; }

    public string? cnt06telefono1 { get; set; }

    public string? cnt06telefono2 { get; set; }

    public string? cnt06celular1 { get; set; }

    public string? cnt06celular2 { get; set; }

    public string? cnt06fax { get; set; }

    public string? cnt06sitioweb { get; set; }

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
