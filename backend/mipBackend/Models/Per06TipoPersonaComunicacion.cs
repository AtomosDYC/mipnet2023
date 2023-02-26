﻿using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Per06TipoPersonaComunicacion
{
    public int per03llave { get; set; }

    public int per04llave { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public Guid? createby { get; set; }

    public virtual Per03TipoPersona Per03LlaveNavigation { get; set; } = null!;

    public virtual Per04TipoComunicacion Per04LlaveNavigation { get; set; } = null!;

    public virtual ICollection<Per05Comunicacion> Per05Comunicacions { get; } = new List<Per05Comunicacion>();
}
