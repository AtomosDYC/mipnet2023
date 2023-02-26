using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Per04TipoComunicacion
{
    public int per04llave { get; set; }

    public string? per04nombre { get; set; }

    public string? per04descripcion { get; set; }

    public int? per04activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Per05Comunicacion> Per05Comunicacions { get; } = new List<Per05Comunicacion>();

    public virtual ICollection<Per06TipoPersonaComunicacion> Per06TipoPersonaComunicacions { get; } = new List<Per06TipoPersonaComunicacion>();
}
