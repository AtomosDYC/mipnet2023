using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Per04TipoComunicacion
{
    public int Per04Llave { get; set; }

    public string? Per04Nombre { get; set; }

    public string? Per04Descripcion { get; set; }

    public int? Per04Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Per05Comunicacion> Per05Comunicacions { get; set; } = new List<Per05Comunicacion>();

    public virtual ICollection<Per06TipoPersonaComunicacion> Per06TipoPersonaComunicacions { get; set; } = new List<Per06TipoPersonaComunicacion>();
}
