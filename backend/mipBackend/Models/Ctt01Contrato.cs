using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Ctt01Contrato
{
    public int Ctt01llave { get; set; }

    public int? Ctt02llave { get; set; }

    public string? Ctt01nombre { get; set; }

    public string? Ctt01descripcion { get; set; }

    public string? Ctt01ContratoHtml { get; set; }

    public int? Ctt01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Ctt02TipoContrato? Ctt02llaveNavigation { get; set; }

    public virtual ICollection<Lnc03LicenciaContrato> Lnc03LicenciaContratos { get; } = new List<Lnc03LicenciaContrato>();
}
