using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Serv01Servicio
{
    public int Serv01llave { get; set; }

    public int? Serv02llave { get; set; }

    public string? Serv01nombre { get; set; }

    public string? Serv01descripcion { get; set; }

    public int? Serv01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Lnc02ServiciosLicencia> Lnc02ServiciosLicencia { get; } = new List<Lnc02ServiciosLicencia>();

    public virtual Serv02TipoServicio? Serv02llaveNavigation { get; set; }
}
