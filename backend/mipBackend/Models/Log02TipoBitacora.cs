using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Log02TipoBitacora
{
    public Guid Log02Llave { get; set; }

    public string? Log02Nombre { get; set; }

    public string? Log02Descripcion { get; set; }

    public int? Log02EsSistema { get; set; }

    public int? Log02EsRazor { get; set; }

    public string? Log02Info { get; set; }

    public int? Log02Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Log03MensajeBitacora> Log03MensajeBitacoras { get; } = new List<Log03MensajeBitacora>();
}
