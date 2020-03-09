using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using Senai.Inlock.WebApi.Repositories;

namespace Senai.Inlock.WebApi.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class JogosController : ControllerBase
    {
        JogosRepository banco = new JogosRepository();

        /// <summary>
        /// Lista de Jogos
        /// </summary>
        /// <returns>Retorna a lista de jogos</returns>
        [HttpGet]
        public IEnumerable<Jogos> Get()
        {
            return banco.Get();
        }

        /// <summary>
        /// Cadastrar Jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns> Cadastra um novo jogo</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Jogos novoJogo)
        {
            try
            {
                banco.Post(novoJogo);
                return Ok(banco.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Um método que busca pelo id do usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                return Ok(banco.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"O id inserido pode estar indisponível: {ex.Message}");
            }
        }


        /// <summary>
        /// Um método que deleta um usuário existente no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Jogos jogo = banco.BuscarPorId(id);
            if (jogo != null)
            {
                return Ok(jogo);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("Estudios/{id}")]
        public IActionResult ListarJogosPorEstudio(int id)
        {
            var bd = banco.BuscarPorId(id);
            if (bd != null)
            {
                try
                {
                    return Ok(banco.ListarPorEstudio(id));
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }
            }
            else
            {
                return NotFound("A lista está vazia");
            }
        }
    }
}