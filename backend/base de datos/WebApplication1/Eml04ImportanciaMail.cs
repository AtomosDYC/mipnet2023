using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Eml04ImportanciaMail
{
    public int Eml04Llave { get; set; }

    public string? Eml04Nombre { get; set; }

    public string? Eml04Descripcion { get; set; }

    public int? Eml04Activo { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Eml01BitacoraEmailUsuario> Eml01BitacoraEmailUsuarios { get; set; } = new List<Eml01BitacoraEmailUsuario>();

    public virtual ICollection<Eml02MailBase> Eml02MailBases { get; set; } = new List<Eml02MailBase>();
}
