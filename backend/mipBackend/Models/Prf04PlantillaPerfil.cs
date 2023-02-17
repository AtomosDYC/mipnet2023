using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Prf04PlantillaPerfil
{
    public int Prf03Llave { get; set; }

    public int Wkf06Llave { get; set; }

    public int? Prf04Activo { get; set; }

    public virtual Prf03Plantilla Prf03LlaveNavigation { get; set; } = null!;

    public virtual Wkf06Perfil Wkf06LlaveNavigation { get; set; } = null!;
}
