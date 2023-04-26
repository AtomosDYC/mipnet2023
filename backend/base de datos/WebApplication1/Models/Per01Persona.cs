using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

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

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt01CuentaCliente> Cnt01CuentaClientes { get; set; } = new List<Cnt01CuentaCliente>();

    public virtual ICollection<Cnt12Empleado> Cnt12Empleados { get; set; } = new List<Cnt12Empleado>();

    public virtual Per02Genero? Per02LlaveNavigation { get; set; }

    public virtual Per03TipoPersona? Per03LlaveNavigation { get; set; }

    public virtual ICollection<Per05Comunicacion> Per05Comunicacions { get; set; } = new List<Per05Comunicacion>();

    public virtual ICollection<Per07PersonaUsuario> Per07PersonaUsuarios { get; set; } = new List<Per07PersonaUsuario>();
}
