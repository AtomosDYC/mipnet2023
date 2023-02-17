using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Esp07Union
{
    public decimal Esp03Llave { get; set; }

    public decimal Esp03LlaveUnion { get; set; }

    public virtual Esp03EspecieBase Esp03LlaveNavigation { get; set; } = null!;
}
