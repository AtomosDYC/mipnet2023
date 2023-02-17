using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Serv01Servicio
{
    public int Serv01Llave { get; set; }

    public int? Serv02Llave { get; set; }

    public string? Serv01Nombre { get; set; }

    public string? Serv01Descripcion { get; set; }

    public int? Serv01Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Lnc02ServiciosLicencia> Lnc02ServiciosLicencia { get; } = new List<Lnc02ServiciosLicencia>();

    public virtual Serv02TipoServicio? Serv02LlaveNavigation { get; set; }
}
