using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Serv02TipoServicio
{
    public decimal Serv02Llave { get; set; }

    public string? Serv02Nombre { get; set; }

    public string? Serv02Descripcion { get; set; }

    public int? Serv02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Serv01Servicio> Serv01Servicios { get; } = new List<Serv01Servicio>();
}
