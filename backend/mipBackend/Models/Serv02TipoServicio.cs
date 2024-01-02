using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Serv02TipoServicio
{
    public int Serv02llave { get; set; }

    public string? Serv02nombre { get; set; }

    public string? Serv02descripcion { get; set; }

    public int? Serv02activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Serv01Servicio> Serv01Servicios { get; } = new List<Serv01Servicio>();
}
