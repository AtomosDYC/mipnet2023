using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Lnc01Licencia
{
    public int Lnc01Llave { get; set; }

    public string? Lnc01Nombre { get; set; }

    public string? Lnc01Descripcion { get; set; }

    public int? Lnc04Llave { get; set; }

    public int? Lnc01MaximoUsuarios { get; set; }

    public int? Lnc01NumeroDias { get; set; }

    public string? Lnc01TextoDias { get; set; }

    public int? Lnc01VisibleUsuario { get; set; }

    public string? Lnc01Imagen { get; set; }

    public string? Lnc01Html { get; set; }

    public int? Lnc01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Lnc02ServiciosLicencium> Lnc02ServiciosLicencia { get; set; } = new List<Lnc02ServiciosLicencium>();

    public virtual ICollection<Lnc03LicenciaContrato> Lnc03LicenciaContratos { get; set; } = new List<Lnc03LicenciaContrato>();

    public virtual ICollection<Lnc05ValorLicencium> Lnc05ValorLicencia { get; set; } = new List<Lnc05ValorLicencium>();

    public virtual ICollection<Lnc06Cobertura> Lnc06Coberturas { get; set; } = new List<Lnc06Cobertura>();

    public virtual ICollection<Lnc07Control> Lnc07Controls { get; set; } = new List<Lnc07Control>();
}
