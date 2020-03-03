using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using Senai.Inlock.WebApi.Repositories;

namespace Senai.Inlock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private UsuariosInterface usuarios;

        public LoginController()
        {
            usuarios = new UsuariosRepository();
        }



        /// <summary>
        /// Processo de login do usuário. 
        /// </summary>
        /// <param name="usuarios"></param>
        /// <returns>Retorna uma chave de acesso privada (token)</returns>
        [HttpPost]
        public IActionResult Autenticar(UsuariosDomain usuarios)
        {
            UsuariosDomain domain = this.usuarios.Comparar(usuarios.Email, usuarios.Senha);
            if (domain != null)
            {
                var claims = new[]
                {
                   new Claim(JwtRegisteredClaimNames.Email, domain.Email),
                   new Claim(JwtRegisteredClaimNames.Jti, domain.IdUsuario.ToString()),
                   new Claim(ClaimTypes.Role, domain.TiposUsuario.Titulo)
               };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("c2ef68458373939242f03e2ddce21091"));
                var credencial = new SigningCredentials(chave,SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken
                    (
                    issuer: "Senai.Inlock.WebApi",
                    audience: "Senai.Inlock.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials :credencial
                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token)});
            }
            else
            {
                var mensagemErro = "Dados inválidos";
                return NotFound(mensagemErro);
            }
        }

    }
}