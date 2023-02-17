using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Per06TipoPersonaComunicacion
{
    public decimal Per03Llave { get; set; }

    public decimal Per04Llave { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public Guid? CreateBy { get; set; }

    public virtual Per03TipoPersona Per03LlaveNavigation { get; set; } = null!;

    public virtual Per04TipoComunicacion Per04LlaveNavigation { get; set; } = null!;

    public virtual ICollection<Per05Comunicacion> Per05Comunicacions { get; } = new List<Per05Comunicacion>();
}
