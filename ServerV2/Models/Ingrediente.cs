using System;
using System.Collections.Generic;

namespace ServerV2.Models;

public partial class Ingrediente
{
    public int IngredienteId { get; set; }

    public string? Nombre { get; set; }

    public int ViandaDetalleId { get; set; }

    public double? Peso { get; set; }

    public string? Categoria { get; set; }

    public virtual Apto? oApto { get; set; }

    public virtual DetallesVianda oDetalleVianda { get; set; } = null!;
}
