using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Ctt01Contrato
{
    public int Ctt01Llave { get; set; }

    public int? Ctt02Llave { get; set; }

    public string? Ctt01Nombre { get; set; }

    public string? Ctt01Descripcion { get; set; }

    public string? Ctt01ContratoHtml { get; set; }

    public int? Ctt01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Ctt02TipoContrato? Ctt02LlaveNavigation { get; set; }

    public virtual ICollection<Lnc03LicenciaContrato> Lnc03LicenciaContratos { get; set; } = new List<Lnc03LicenciaContrato>();
}
