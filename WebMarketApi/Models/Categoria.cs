using System;
using System.Collections.Generic;

namespace WebMarketApi.Models;

public partial class Categoria
{
    public int Categoria_id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
