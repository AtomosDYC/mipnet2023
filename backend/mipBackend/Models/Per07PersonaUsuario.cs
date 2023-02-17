using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Per07PersonaUsuario
{
    public int Per07Llave { get; set; }

    public int? Per01Llave { get; set; }

    public Guid? Secu02Llave { get; set; }

    public int? Per07Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Per01Persona? Per01LlaveNavigation { get; set; }
}
