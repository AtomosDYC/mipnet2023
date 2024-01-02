using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class per06TipopersonaComunicacion
{
    public int per03llave { get; set; }

    public int per04llave { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public Guid? createby { get; set; }

    public virtual per03Tipopersona per03llaveNavigation { get; set; } = null!;

    public virtual per04TipoComunicacion per04llaveNavigation { get; set; } = null!;

    public virtual ICollection<per05Comunicacion> per05Comunicacions { get; } = new List<per05Comunicacion>();
}
