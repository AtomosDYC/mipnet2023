using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Eml03TipoMailAccion
{
    public int Eml03llave { get; set; }

    public string? Eml03nombre { get; set; }

    public string? Eml03descripcion { get; set; }

    public int? Eml03activo { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Eml02MailBase> Eml02MailBases { get; } = new List<Eml02MailBase>();
}
