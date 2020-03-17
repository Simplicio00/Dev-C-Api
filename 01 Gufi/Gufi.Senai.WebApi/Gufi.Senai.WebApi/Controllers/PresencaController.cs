using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gufi.Senai.WebApi.Domains;
using Gufi.Senai.WebApi.Repositories;
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
        UsuarioRepository banco2 = new UsuarioRepository();

        /// <summary>
        /// Faz a busca de todas as presenças
        /// </summary>
        /// <returns>Retorna uma lista com todas presenças</returns>

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
        [HttpGet("{id}")]
        public IActionResult PorPessoa(int id)
        {
            var usuario = banco2.GetById(id);
            if (usuario != null)
            {
                var lista = banco.PresencaPorPessoa(id);
                if (lista.Count != 0)
                {
                    return StatusCode(201, lista);
                }
                else
                {
                    return NotFound("O usuário não se inscreveu em nenhum evento");
                }
            }
            else
            {
                return NotFound("Usuário não encontrado");
            }
        }


        /// <summary>
        /// Faz a inscrição de um usuário num evento
        /// </summary>
        /// <param name="presenca">É o processo de cadastro único num evento</param>
        /// <returns>retorna o cadastro concluído</returns>
        [HttpPost]
        public IActionResult Inscrever_Se(Presenca presenca)
        {
            var elemento = banco.Get();
            if (!elemento.Contains(
                elemento.FirstOrDefault(a => a.IdUsuario == presenca.IdUsuario && a.IdEvento == presenca.IdEvento)))
            {
                try
                {
                    banco.Post(presenca);
                    return StatusCode(201, 
                        $"O cadastro do usuário no evento foi concluído com sucesso");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Ocorreu um erro na hora de cadastrar... {ex.Message.ToString()}");
                }
            }
            else
            {
                return BadRequest("Perdão, mas usuário não pode se cadastrar mais de uma vez num mesmo evento...");
            }
           
        }
    }
}