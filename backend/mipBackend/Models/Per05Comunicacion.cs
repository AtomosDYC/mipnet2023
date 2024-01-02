using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class per05Comunicacion
{
    public int per01llave { get; set; }

    public int per04llave { get; set; }

    public int per03llave { get; set; }

    public string? per05direccion { get; set; }

    public int? sist03llave { get; set; }

    public string? per05casilla { get; set; }

    public int? per05tienecasilla { get; set; }

    public string? per05codigopostal { get; set; }

    public string? per05email { get; set; }

    public string? per05telefono1 { get; set; }

    public string? per05telefono2 { get; set; }

    public string? per05celular1 { get; set; }

    public string? per05celular2 { get; set; }

    public string? per05fax { get; set; }

    public string? per05sitioWeb { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual per06TipopersonaComunicacion per0 { get; set; } = null!;

    public virtual per01persona per01llaveNavigation { get; set; } = null!;

    public virtual per03Tipopersona per03llaveNavigation { get; set; } = null!;

    public virtual per04TipoComunicacion per04llaveNavigation { get; set; } = null!;
}
