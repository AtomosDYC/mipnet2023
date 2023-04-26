using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Per05Comunicacion
{
    public int Per01Llave { get; set; }

    public int Per04Llave { get; set; }

    public int Per03Llave { get; set; }

    public string? Per05Direccion { get; set; }

    public int? Sist03Llave { get; set; }

    public string? Per05Casilla { get; set; }

    public int? Per05TieneCasilla { get; set; }

    public string? Per05CodigoPostal { get; set; }

    public string? Per05Email { get; set; }

    public string? Per05Telefono1 { get; set; }

    public string? Per05Telefono2 { get; set; }

    public string? Per05Celular1 { get; set; }

    public string? Per05Celular2 { get; set; }

    public string? Per05Fax { get; set; }

    public string? Per05SitioWeb { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Per06TipoPersonaComunicacion Per0 { get; set; } = null!;

    public virtual Per01Persona Per01LlaveNavigation { get; set; } = null!;

    public virtual Per03TipoPersona Per03LlaveNavigation { get; set; } = null!;

    public virtual Per04TipoComunicacion Per04LlaveNavigation { get; set; } = null!;
}
