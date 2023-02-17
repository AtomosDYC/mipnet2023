using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Eml06TipoArchivo
{
    public int Eml06Llave { get; set; }

    public string? Eml06Nombre { get; set; }

    public string? Eml06Descripcion { get; set; }

    public int? Eml06Activo { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Eml05ArchivoMail? Eml05ArchivoMail { get; set; }
}
