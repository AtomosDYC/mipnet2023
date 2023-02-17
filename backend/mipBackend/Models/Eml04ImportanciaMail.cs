using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Eml04ImportanciaMail
{
    public int Eml04Llave { get; set; }

    public string? Eml04Nombre { get; set; }

    public string? Eml04Descripcion { get; set; }

    public int? Eml04Activo { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Eml01BitacoraEmailUsuario> Eml01BitacoraEmailUsuarios { get; } = new List<Eml01BitacoraEmailUsuario>();

    public virtual ICollection<Eml02MailBase> Eml02MailBases { get; } = new List<Eml02MailBase>();
}
