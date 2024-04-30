using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class Apto
{
    public int AptoId { get; set; }

    public string? Nombre { get; set; }

    public string? ImagenUrl { get; set; }

    public int IngredientesIngredienteId { get; set; }

    public virtual Ingredientes oIngrediente { get; set; } = null!;
}
