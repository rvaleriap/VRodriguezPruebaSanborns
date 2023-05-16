using System;
using System.Collections.Generic;

namespace DL;

public partial class Division
{
    public int IdDivision { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
