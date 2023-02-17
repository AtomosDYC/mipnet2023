using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Ctt01Contrato
{
    public int Ctt01Llave { get; set; }

    public int? Ctt02Llave { get; set; }

    public string? Ctt01Nombre { get; set; }

    public string? Ctt01Descripcion { get; set; }

    public string? Ctt01ContratoHtml { get; set; }

    public int? Ctt01Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Ctt02TipoContrato? Ctt02LlaveNavigation { get; set; }

    public virtual ICollection<Lnc03LicenciaContrato> Lnc03LicenciaContratos { get; } = new List<Lnc03LicenciaContrato>();
}
