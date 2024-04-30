using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerV2.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
namespace ServerV2.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly string secretKey;
        private readonly AppjuanV1Context _context;
        public AutenticacionController(AppjuanV1Context context, IConfiguration config)
        {
            _context = context;
            secretKey = config.GetSection("settings").GetSection("secretket").ToString();
        }

        [HttpPost("ValidarEmail")]
        public async Task<IActionResult> ValidarEmail([FromBody] Acceso request)
        {
            if (request.email == null)
            {
                return BadRequest("El email no puede estar vacío");
            }

            // Buscar al cliente por su email en la base de datos
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == request.email);

            if (cliente != null)
            {
                var token = GenerateToken(request.email);
                return Ok(new { token, user = cliente });
            }
            else
            {
                var nuevoCliente = new Cliente
                {
                    Email = request.email,
                    Nombre = request.given_name,
                    Apellido = request.family_name
                };

                var ultimoCliente = await _context.Clientes.OrderByDescending(c => c.ClienteId).FirstOrDefaultAsync();
                nuevoCliente.ClienteId = ultimoCliente != null ? ultimoCliente.ClienteId + 1 : 1;

                _context.Clientes.Add(nuevoCliente);
                await _context.SaveChangesAsync();

                var token = GenerateToken(request.email);
                return Ok(new { token, user = nuevoCliente });
            }
        }
       

        // Método para generar un token JWT
        private string GenerateToken(string email)
        {
            var keyBytes = Encoding.ASCII.GetBytes(secretKey);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, email));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5), // token expira en 5 minutos
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(tokenConfig);
        }

        

    }
}
