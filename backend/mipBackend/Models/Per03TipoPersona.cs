using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Per03TipoPersona
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

    public virtual ICollection<Cnt03TipoCliente> Cnt03TipoClientes { get; } = new List<Cnt03TipoCliente>();

    public virtual ICollection<Per01Persona> Per01Personas { get; } = new List<Per01Persona>();

    public virtual ICollection<Per05Comunicacion> Per05Comunicacions { get; } = new List<Per05Comunicacion>();

    public virtual ICollection<Per06TipoPersonaComunicacion> Per06TipoPersonaComunicacions { get; } = new List<Per06TipoPersonaComunicacion>();

}
