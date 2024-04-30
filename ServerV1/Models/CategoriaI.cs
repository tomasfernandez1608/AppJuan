using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class CategoriaI
{
    public int TipoId { get; set; }

    public string? Nombre { get; set; }

    public virtual Ingredientes? oIngrediente { get; set; }
}
