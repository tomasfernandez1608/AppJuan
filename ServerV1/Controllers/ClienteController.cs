using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerV1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
namespace ServerV1.Controllers
{
    [EnableCors("ConfigCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppjuantestV1Context _context;

        public ClienteController(AppjuantestV1Context context)
        {
            _context = context;
        }

        // GET: api/Cliente/Listar
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _context.Clientes
                .Select(c => new Cliente
                {
                    UsuarioId = c.UsuarioId,
                    Direccion = c.Direccion,
                    CodigoPostal = c.CodigoPostal,
                    Peso = c.Peso,
                    Altura = c.Altura,
                    Objetivo = c.Objetivo,
                    oUsuario = c.oUsuario
                })
                .ToListAsync();


            return clientes;
        }

        // GET: api/Cliente/5
        [HttpGet("Listar/{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }
        // Post: api/Cliente/Alta
        [HttpPost("Alta")]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente clienteViewModel)
        {
            // Obtener el último UsuarioId usado
            var ultimoUsuarioId = await _context.Usuarios.MaxAsync(c => (int?)c.UsuarioId) ?? 0;

            // Incrementar el UsuarioId para el nuevo cliente
            clienteViewModel.UsuarioId = ultimoUsuarioId + 1;
            // Crear un nuevo objeto Usuario con los datos proporcionados en el ViewModel
            var nuevoUsuario = new Usuarios
            {
                UsuarioId = clienteViewModel.UsuarioId,
                Nombre = clienteViewModel.oUsuario.Nombre,
                Apellido = clienteViewModel.oUsuario.Apellido,
                Email = clienteViewModel.oUsuario.Email,
                Password = clienteViewModel.oUsuario.Password
               
            };

            // Agregar el nuevo usuario a la base de datos
            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            // Crear un nuevo objeto Cliente utilizando el UsuarioId generado
            var nuevoCliente = new Cliente
            {
                UsuarioId = nuevoUsuario.UsuarioId,
                Direccion = clienteViewModel.Direccion,
                CodigoPostal = clienteViewModel.CodigoPostal,
                Peso = clienteViewModel.Peso,
                Altura = clienteViewModel.Altura,
                Objetivo = clienteViewModel.Objetivo
                
            };

            // Agregar el nuevo cliente a la base de datos
            _context.Clientes.Add(nuevoCliente);
            await _context.SaveChangesAsync();

            // Devolver la respuesta con el nuevo cliente y su UsuarioId asignado
            return CreatedAtAction("GetCliente", new { id = nuevoCliente.UsuarioId }, nuevoCliente);
        }


        // PUT: api/Cliente/Actualizar/5
        [HttpPut("/Actualizar{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Cliente/Eliminar/5
        [HttpDelete("/Eliminar/{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.UsuarioId == id);
        }
    }
}
