using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class Suscripciones
{
    public int SuscripcionId { get; set; }

    public DateTime? FechaIncripcion { get; set; }

    public DateTime? FechaRenovacion { get; set; }

    public int? ConsultasRealizadas { get; set; }

    public int? ObjetivosCumplidos { get; set; }

    public double? PesoAlcanzar { get; set; }

    public int ClienteUsuarioId { get; set; }

    public int? VConsumidas { get; set; }

    public virtual Cliente ClienteUsuario { get; set; } = null!;
}
