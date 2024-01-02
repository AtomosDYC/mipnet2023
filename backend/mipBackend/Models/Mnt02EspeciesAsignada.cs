using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Mnt02EspeciesAsignada
{
    public int mnt01llave { get; set; }

    public int esp02llave { get; set; }

    public virtual Mnt01Monitor Mnt01llaveNavigation { get; set; } = null!;

    public virtual esp02Temporadaespecie esp02llaveNavigation { get; set; } = null!;

}

