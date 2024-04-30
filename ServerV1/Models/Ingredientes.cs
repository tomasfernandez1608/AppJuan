using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class Ingredientes
{
    public int IngredienteId { get; set; }

    public string? Nombre { get; set; }

    public int DetallesViandaDetalleId { get; set; }

    public int CategoriaITipoId { get; set; }

    public double? Peso { get; set; }

    public virtual Apto? Apto { get; set; }

    public virtual CategoriaI oCategoriaI { get; set; } = null!;

    public virtual DetallesVianda oDetallesVianda { get; set; } = null!;
}
