using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ServerV1.Models;
/*{
  "usuarioId": 0,
  "nombre": "string",
  "apellido": "string",
  "email": "string",
  "password": "string"
}*/
public partial class Usuarios
{

    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    [JsonIgnore]
    public virtual Admin? Admin { get; set; }
    [JsonIgnore]
    public virtual Cliente? Cliente { get; set; }
    [JsonIgnore]
    public virtual ICollection<Pedidos> oPedidos { get; set; } = new List<Pedidos>();
    [JsonIgnore]
    public virtual Profesionales? Profesional { get; set; }
}
