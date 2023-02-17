using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Eml05ArchivoMail
{
    public decimal Eml05Llave { get; set; }

    public decimal? Eml01Llave { get; set; }

    public decimal? Eml06Llave { get; set; }

    public string? Eml05Archivo { get; set; }

    public string? Eml05Ruta { get; set; }

    public int? Eml05Activo { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Eml01BitacoraEmailUsuario? Eml01LlaveNavigation { get; set; }

    public virtual Eml06TipoArchivo Eml05LlaveNavigation { get; set; } = null!;
}
