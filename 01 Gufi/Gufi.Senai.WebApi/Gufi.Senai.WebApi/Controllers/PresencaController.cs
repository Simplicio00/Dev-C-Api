using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Gufi.Senai.WebApi.Domains;
using Gufi.Senai.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gufi.Senai.WebApi.Controllers
{   
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PresencaController : ControllerBase
    {
        PresencaRepository banco = new PresencaRepository();

        /// <summary>
        /// Faz a busca de todas as presenças
        /// </summary>
        /// <returns>Retorna uma lista com todas presenças</returns>

            [Authorize(Roles ="1")]
        [HttpGet]
        public IActionResult Get()
        {
            var lista = banco.Get();
            if (lista.Count != 0)
            {
                return Ok(lista);
            }
            else
            {
                return NotFound("A lista de presenças está vazia");
            }
        }

        /// <summary>
        /// Faz uma busca de todas as presenças no qual um determinado usuário está contido
        /// </summary>
        /// <param name="id">Identificador único do usuário</param>
        /// <returns>Retorna uma lista de eventos dos quais o usuário se inscreveu</returns>
        [Authorize]
        [HttpGet("Minhas")]
        public IActionResult PorPessoa()
        {
            var usuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

            var lista = banco.PresencaPorPessoa(usuario);

               if (lista.Count != 0)
                {
                    return Ok(lista);
                }
                else
                {
                    return NotFound("O usuário não se inscreveu em nenhum evento");
                }
       }
           


        /// <summary>
        /// Faz a inscrição de um usuário num evento
        /// </summary>
        /// <param name="presenca">É o processo de cadastro único num evento</param>
        /// <returns>retorna o cadastro concluído</returns>
        
        [Authorize]
        [HttpPost("Inscricao/{idEvento}")]
        public IActionResult Inscrever_Se(int idEvento)
        {

            try
            {
                Presenca inscricao = new Presenca()
                {
                    IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value),
                    IdEvento = idEvento,
                    Situacao = "Não confirmada"
                };

                var elemento = banco.Get();

                if (!elemento.Contains(
                    elemento.FirstOrDefault(a => a.IdUsuario == inscricao.IdUsuario && a.IdEvento == inscricao.IdEvento)))
                {
                    try
                    {
                        banco.Post(inscricao);
                        return StatusCode(201);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest($"Ocorreu um erro na hora de cadastrar... {ex.Message.ToString()}");
                    }
                }
                else
                {
                    return BadRequest("Perdão, mas o usuário não pode se cadastrar mais de uma vez num mesmo evento...");
                }

            }
            catch (Exception)
            {

                throw;
            }
           
        }


        [Authorize(Roles ="1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Presenca status)
        {
            try
            {
                banco.Aprovacao(id, status.Situacao);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message.ToString());
            }
        }


        [Authorize]
        [HttpPost("Convidar")]
        public IActionResult Invite(Presenca convite)
        {
            try
            {
                banco.Convidar(convite);
                
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }


    }
}