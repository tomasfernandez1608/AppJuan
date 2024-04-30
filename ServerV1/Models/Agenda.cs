using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class Agenda
{
    public int AgendaId { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public int ClienteUsuarioId { get; set; }

    public int ProfesionalesUsuarioId { get; set; }

    public string? MeetUrl { get; set; }

    public string? Comentarios { get; set; }

    public virtual Cliente ClienteUsuario { get; set; } = null!;

    public virtual Profesionales ProfesionalesUsuario { get; set; } = null!;
}
