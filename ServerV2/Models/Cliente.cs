using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ServerV2.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? CodigoPostal { get; set; }

    public double? Peso { get; set; }

    public double? Altura { get; set; }

    public string? Objetivo { get; set; }
    [JsonIgnore]
    public virtual Agenda? oAgenda { get; set; }
    [JsonIgnore]
    public virtual ICollection<Pedido> oPedidos { get; set; } = new List<Pedido>();
    [JsonIgnore]
    public virtual ICollection<Progreso> oProgresos { get; set; } = new List<Progreso>();
    [JsonIgnore]
    public virtual Suscripcion? oSuscripcion { get; set; }
}
