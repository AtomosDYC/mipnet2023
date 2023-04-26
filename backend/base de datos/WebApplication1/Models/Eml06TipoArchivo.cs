using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Eml06TipoArchivo
{
    public int Eml06Llave { get; set; }

    public string? Eml06Nombre { get; set; }

    public string? Eml06Descripcion { get; set; }

    public int? Eml06Activo { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Eml05ArchivoMail? Eml05ArchivoMail { get; set; }
}
