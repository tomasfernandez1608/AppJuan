using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class DetallesVianda
{
    public int DetalleId { get; set; }

    public int? Cantidad { get; set; }

    public string? Unidad { get; set; }

    public virtual ICollection<Ingredientes> oIngredientes { get; set; } = new List<Ingredientes>();

    public virtual ICollection<Vianda> oVianda { get; set; } = new List<Vianda>();
}
