using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.filmes.webapi.Domains;
using Senai.filmes.webapi.Interfaces;
using Senai.filmes.webapi.Repositories;

namespace Senai.filmes.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUsuarioDomain usuario;

        public UsuarioController(){
            usuario = new UsuarioRepository();
        }

        public IActionResult Post(UsuarioDomain Login)
        {
            UsuarioDomain usuarioBuscado = usuario.BuscaPorEmailSenha(Login.Email, Login.Senha);
            if (usuarioBuscado == null)
            {
                var invalid = "O acesso foi negado ou inexiste, contate o administrador";
                return NotFound(invalid);
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.Permissao),
                // new Claim("Claim Personalizada", "Teste")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao"));
            var creds = new SigningCredentials(key, SecurityAlgorithms. HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "Senai.filmes.webApi", audience: "Senai.filmes.webApi", claims: claims, expires: DateTime.Now.AddMinutes(10), signingCredentials: creds);
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}