using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class prf01perfil
{
    public int prf01llave { get; set; }

    public int? prf03llave { get; set; }

    public Guid? userid { get; set; }

    public int? prf01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual prf03Plantilla? prf03llavenavigation { get; set; }

}
