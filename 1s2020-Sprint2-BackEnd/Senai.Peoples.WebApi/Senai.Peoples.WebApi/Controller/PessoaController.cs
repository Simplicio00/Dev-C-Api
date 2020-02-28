using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class PessoaController : ControllerBase
    {
        private IPessoa pessoa { get; set; }
        public PessoaController()
        {
            pessoa = new PessoaRepository();
        }

        // Requisições


        [Authorize]
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var lista = pessoa.Listar();

            if (lista != null)
            {
                return Ok(lista);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Cadastrar(PessoaDomain pessoa)
        {
            try
            {
                this.pessoa.Post(pessoa);
                return Ok(this.pessoa.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscaPeloId(int id)
        {
            try
            {
                return Ok(pessoa.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            PessoaDomain domain;
            domain = pessoa.BuscarPorId(id);

            if (domain != null)
            {
                pessoa.Delete(id);
                return Ok(pessoa.Listar());
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, PessoaDomain pessoa)
        {
            PessoaDomain domain;
            domain = this.pessoa.BuscarPorId(id);

            if (domain != null)
            {
                try
                {
                    this.pessoa.Atualizar(id, pessoa);
                    return Ok(this.pessoa.Listar());
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("nome/{nome}")]
        public IActionResult BuscarPeloNome(string nome)
        {
            if (nome != null)
            {
                try
                {
                    return Ok(pessoa.BuscarPorNome(nome));
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }
            }
            else
            {
                return BadRequest();
            }

        }



        /////////// login //////////////////////  \o/ \\\\\\\\\\\\\\\\ \o/

        // Parte do login


        [HttpPost("login")]
        public IActionResult Post(PessoaDomain pessoa)
        {
            PessoaDomain domain = this.pessoa.BuscarPorEmailSenha(pessoa.Email, pessoa.Senha);
            if (domain == null)
            {
                return NotFound("Email ou senha inválidos");
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, domain.Email),
                new Claim(JwtRegisteredClaimNames.Jti, domain.IdTipoUsuario.ToString()),
                new Claim(ClaimTypes.Role, domain.tipoUsuario.TipoUsuario),
            };

            var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("teste"));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "Senai.Peoples", 
                audience: "Senai.Peoples", 
                claims: claims, 
                expires: DateTime.Now.AddMinutes(30), 
                signingCredentials: credencial);

           IdentityModelEventSource.ShowPII = true;

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token)});
        }


    }
}