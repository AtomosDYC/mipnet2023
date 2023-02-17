using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Prf04PlantillaPerfil
{
    public decimal Prf03Llave { get; set; }

    public decimal Wkf06Llave { get; set; }

    public int? Prf04Activo { get; set; }

    public virtual Prf03Plantilla Prf03LlaveNavigation { get; set; } = null!;

    public virtual Wkf06Perfile Wkf06LlaveNavigation { get; set; } = null!;
}
