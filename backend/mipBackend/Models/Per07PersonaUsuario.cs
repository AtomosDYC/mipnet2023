using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class per07personaUsuario
{
    public int per07llave { get; set; }

    public int? per01llave { get; set; }

    public Guid? userid { get; set; }

    public int? per07activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual per01persona? per01llaveNavigation { get; set; }
}
