using System;
using System.Collections.Generic;

namespace ServerV2.Models;

public partial class Agenda
{
    public int AgendaId { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string? MeetUrl { get; set; }

    public string? Comentarios { get; set; }

    public int ClienteId { get; set; }

    public int ProfesionalId { get; set; }

    public virtual Cliente oCliente { get; set; } = null!;

    public virtual Profesional oProfesional { get; set; } = null!;
}
