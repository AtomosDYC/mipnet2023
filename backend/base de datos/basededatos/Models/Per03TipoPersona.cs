using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Per03TipoPersona
{
    public decimal Per03Llave { get; set; }

    public string? Per03Nombre { get; set; }

    public string? Per03Descripcion { get; set; }

    public int? Per03Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt03TipoCliente> Cnt03TipoClientes { get; } = new List<Cnt03TipoCliente>();

    public virtual ICollection<Per01Persona> Per01Personas { get; } = new List<Per01Persona>();

    public virtual ICollection<Per05Comunicacion> Per05Comunicacions { get; } = new List<Per05Comunicacion>();

    public virtual ICollection<Per06TipoPersonaComunicacion> Per06TipoPersonaComunicacions { get; } = new List<Per06TipoPersonaComunicacion>();
}
