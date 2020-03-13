using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Gufi.Senai.WebApi.Domains;
using Gufi.Senai.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Gufi.Senai.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        UsuarioRepository banco = new UsuarioRepository();


        [HttpPost]
        public IActionResult Login(string Email, string Senha)
        {
            Usuario usuario = banco.Comparar(Email,Senha);
            if (usuario != null)
            {
                var claims = new[]
               {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString())
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("0d13199c64d04f59d9e56a68f1844d09"));
                var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                   issuer: "Gufi.Senai.WebApi",
                   audience: "Gufi.Senai.WebApi",
                   claims: claims,
                   expires: DateTime.Now.AddMinutes(20),
                   signingCredentials: credencial
                   );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }
            else
            {
                return NotFound("Dados incorretos");
            }
        }
    }
}