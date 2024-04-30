using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ServerV1.Models;

public partial class Cliente
{

    public int UsuarioId { get; set; }

    public string? Direccion { get; set; }

    public string? CodigoPostal { get; set; }

    public double? Peso { get; set; }

    public double? Altura { get; set; }

    public string? Objetivo { get; set; }
    
    public virtual Agenda? oAgenda { get; set; }
    
    public virtual ICollection<Progresos> oProgresos { get; set; } = new List<Progresos>();
    
    public virtual Suscripciones? oSuscripciones { get; set; }
    
    public virtual Usuarios oUsuario { get; set; }
}
