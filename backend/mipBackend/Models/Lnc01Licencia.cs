using System;
using System.Collections.Generic;

namespace mipBackend.Models;

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

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Lnc02ServiciosLicencia> Lnc02ServiciosLicencia { get; } = new List<Lnc02ServiciosLicencia>();

    public virtual ICollection<Lnc03LicenciaContrato> Lnc03LicenciaContratos { get; } = new List<Lnc03LicenciaContrato>();

    public virtual ICollection<Lnc05ValorLicencia> Lnc05ValorLicencia { get; } = new List<Lnc05ValorLicencia>();

    public virtual ICollection<Lnc06Cobertura> Lnc06Coberturas { get; } = new List<Lnc06Cobertura>();

    public virtual ICollection<Lnc07Control> Lnc07Controls { get; } = new List<Lnc07Control>();
}
