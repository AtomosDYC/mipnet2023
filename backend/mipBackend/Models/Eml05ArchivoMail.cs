using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Eml05ArchivoMail
{
    public int Eml05Llave { get; set; }

    public int? Eml01Llave { get; set; }

    public int? Eml06Llave { get; set; }

    public string? Eml05Archivo { get; set; }

    public string? Eml05Ruta { get; set; }

    public int? Eml05Activo { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Eml01BitacoraEmailUsuario? Eml01LlaveNavigation { get; set; }

    public virtual Eml06TipoArchivo Eml05LlaveNavigation { get; set; } = null!;
}
