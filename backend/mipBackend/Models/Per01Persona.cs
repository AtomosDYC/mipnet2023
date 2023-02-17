using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Per01Persona
{
    public int Per01Llave { get; set; }

    public int? Per01Rut { get; set; }

    public int? Per03Llave { get; set; }

    public int? Per02Llave { get; set; }

    public string? Per01NombreRazon { get; set; }

    public string? Per01NombreFantasia { get; set; }

    public string? Per01Giro { get; set; }

    public string? Per01Cargo { get; set; }

    public DateTime? Per01FechaNacimiento { get; set; }

    public int? Per01AnioIngreso { get; set; }

    public int? Per01Activo { get; set; }

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
