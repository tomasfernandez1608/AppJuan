using System;
using System.Collections.Generic;

namespace ServerV2.Models;

public partial class Suscripcion
{
    public int SuscripcionId { get; set; }

    public DateTime? FechaIncripcion { get; set; }

    public DateTime? FechaRenovacion { get; set; }

    public int? ConsultasRealizadas { get; set; }

    public int? ObjetivosCumplidos { get; set; }

    public double? PesoAlcanzar { get; set; }

    public int? VConsumidas { get; set; }

    public int ClienteId { get; set; }

    public virtual Cliente oCliente { get; set; } = null!;
}
