using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Serv02TipoServicio
{
    public int Serv02Llave { get; set; }

    public string? Serv02Nombre { get; set; }

    public string? Serv02Descripcion { get; set; }

    public int? Serv02Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Serv01Servicio> Serv01Servicios { get; } = new List<Serv01Servicio>();
}
