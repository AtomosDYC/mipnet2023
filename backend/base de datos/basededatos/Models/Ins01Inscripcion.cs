using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Ins01Inscripcion
{
    public decimal Ins01Llave { get; set; }

    public decimal? Ins01Rut { get; set; }

    public decimal? Per02Llave { get; set; }

    public string? Ins01Nombre { get; set; }

    public string? Ins01Apellido { get; set; }

    public string? Ins01Empresa { get; set; }

    public decimal? Sist03Llave { get; set; }

    public string? Ins01Direccion { get; set; }

    public string? Ins01Telefono { get; set; }

    public DateTime? Ins01FechaNacimiento { get; set; }

    public string? Ins01Email { get; set; }

    public DateTime? Ins01FechaInscripcion { get; set; }

    public int? Ins01Activo { get; set; }

    public DateTime? Ins01FechaActivacion { get; set; }

    public string? Ins01UserName { get; set; }

    public string? Ins01Password { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }
}
