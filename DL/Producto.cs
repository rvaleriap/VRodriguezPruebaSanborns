using System;
using System.Collections.Generic;

namespace DL;

public partial class Producto
{
    public int Sku { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precioventa { get; set; }

    public string? Descuento { get; set; }

    public string? Impuesto { get; set; }

    public int? IdDivision { get; set; }

    public virtual Division? IdDivisionNavigation { get; set; }
    public string NombreDivision { get; set; }
}
