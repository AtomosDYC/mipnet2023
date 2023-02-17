using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Eml04ImportanciaMail
{
    public decimal Eml04Llave { get; set; }

    public string? Eml04Nombre { get; set; }

    public string? Eml04Descripcion { get; set; }

    public int? Eml04Activo { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Eml01BitacoraEmailUsuario> Eml01BitacoraEmailUsuarios { get; } = new List<Eml01BitacoraEmailUsuario>();

    public virtual ICollection<Eml02MailBase> Eml02MailBases { get; } = new List<Eml02MailBase>();
}
