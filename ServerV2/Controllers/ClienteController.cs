using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerV2.Models;
using BCrypt.Net;

namespace ServerV2.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    [Route("/api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppjuanV1Context _context;

        public ClienteController(AppjuanV1Context context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            // Seleccionar todos los clientes excluyendo la contraseña
            var clientes = await _context.Clientes
                                        .Select(c => new Cliente
                                        {
                                            ClienteId = c.ClienteId,
                                            Email = c.Email,
                                            Nombre = c.Nombre,
                                            Apellido = c.Apellido,
                                            Direccion = c.Direccion,
                                            CodigoPostal = c.CodigoPostal,
                                            Peso = c.Peso,
                                            Altura = c.Altura,
                                            Objetivo = c.Objetivo
                                        })
                                        .ToListAsync();

            return clientes;
        }

 
        [HttpGet("BuscarClienteEmail")]
        public async Task<ActionResult<Cliente>> GetClientePorEmail([FromQuery] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("El email no puede estar vacío");
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);

            if (cliente == null)
            {
                return NotFound($"No se encontró ningún cliente con el email {email}");
            }

            return cliente;
        }

    }
}
