using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class per03Tipopersona
{
    public int per03llave { get; set; }

    public string? per03nombre { get; set; }

    public string? per03descripcion { get; set; }

    public int? per03activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<cnt03TipoCliente> cnt03TipoClientes { get; } = new List<cnt03TipoCliente>();

    public virtual ICollection<per01persona> per01personas { get; } = new List<per01persona>();

    public virtual ICollection<per05Comunicacion> per05Comunicacions { get; } = new List<per05Comunicacion>();

    public virtual ICollection<per06TipopersonaComunicacion> per06TipopersonaComunicacions { get; } = new List<per06TipopersonaComunicacion>();

}
