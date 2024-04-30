using System;
using System.Collections.Generic;

namespace ServerV2.Models;

public partial class DetallesVianda
{
    public int DetalleId { get; set; }

    public int? Cantidad { get; set; }

    public string? Unidad { get; set; }

    public virtual ICollection<Ingrediente> oIngredientes { get; set; } = new List<Ingrediente>();

    public virtual ICollection<Vianda> oVianda { get; set; } = new List<Vianda>();
}
