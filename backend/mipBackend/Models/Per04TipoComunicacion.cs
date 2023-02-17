using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Per04TipoComunicacion
{
    public int Per04Llave { get; set; }

    public string? Per04Nombre { get; set; }

    public string? Per04Descripcion { get; set; }

    public int? Per04Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Per05Comunicacion> Per05Comunicacions { get; } = new List<Per05Comunicacion>();

    public virtual ICollection<Per06TipoPersonaComunicacion> Per06TipoPersonaComunicacions { get; } = new List<Per06TipoPersonaComunicacion>();
}
