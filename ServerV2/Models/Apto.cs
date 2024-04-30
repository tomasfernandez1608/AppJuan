using System;
using System.Collections.Generic;

namespace ServerV2.Models;

public partial class Apto
{
    public int AptoId { get; set; }

    public string? Nombre { get; set; }

    public string? ImagenUrl { get; set; }

    public int IngredienteId { get; set; }

    public virtual Ingrediente oIngrediente { get; set; } = null!;
}
