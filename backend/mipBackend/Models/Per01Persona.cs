using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Per01Persona
{
    public int per01llave { get; set; }

    public int? per01rut { get; set; }

    public int? per03llave { get; set; }

    public int? per08llave { get; set; }

    public int? per02llave { get; set; }

    public string? per01nombrerazon { get; set; }

    public string? per01nombrefantasia { get; set; }

    public string? per01giro { get; set; }

    public string? per01cargo { get; set; }

    public DateTime? per01fechanacimiento { get; set; }

    public int? per01anioingreso { get; set; }

    public int? per01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Cnt01CuentaCliente> Cnt01CuentaClientes { get; } = new List<Cnt01CuentaCliente>();

    public virtual ICollection<Cnt12Empleado> Cnt12Empleados { get; } = new List<Cnt12Empleado>();

    public virtual Per02Genero? Per02LlaveNavigation { get; set; }

    public virtual Per03TipoPersona? Per03LlaveNavigation { get; set; }

    public virtual ICollection<Per05Comunicacion> Per05Comunicacions { get; } = new List<Per05Comunicacion>();

    public virtual ICollection<Per07PersonaUsuario> Per07PersonaUsuarios { get; } = new List<Per07PersonaUsuario>();
}
