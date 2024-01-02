using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Log03MensajeBitacora
{
    public int Log03llave { get; set; }

    public Guid? Log02llave { get; set; }

    public string? Log03AccesoRapido { get; set; }

    public string? Log03descripcion { get; set; }

    public string? Log03Mensaje { get; set; }

    public int? Log03activo { get; set; }

    public string? Log03Info { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Log01Bitacora> Log01Bitacoras { get; } = new List<Log01Bitacora>();

    public virtual Log02TipoBitacora? Log02llaveNavigation { get; set; }
}
