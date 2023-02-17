using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Serv01Servicio
{
    public decimal Serv01Llave { get; set; }

    public decimal? Serv02Llave { get; set; }

    public string? Serv01Nombre { get; set; }

    public string? Serv01Descripcion { get; set; }

    public int? Serv01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Lnc02ServiciosLicencium> Lnc02ServiciosLicencia { get; } = new List<Lnc02ServiciosLicencium>();

    public virtual Serv02TipoServicio? Serv02LlaveNavigation { get; set; }
}
