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
    public class UsuariosController : ControllerBase
    {
        UsuarioRepository banco = new UsuarioRepository();

        /// <summary>
        /// Faz a listagem de todos os usuários
        /// </summary>
        /// <returns></returns>
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
                return NotFound("A lista está vazia");
            }
        }

        /// <summary>
        /// Busca um usuário pelo seu identificador único
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Usuario user = banco.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("O usuário da requisição não foi encontrado");
            }
        }

        
        /// <summary>
        /// Faz o cadastro de um usuário no sistema
        /// </summary>
        /// <param name="usuario">objeto que será cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                banco.Post(usuario);
                var msg = string.Format($"O usuário {usuario.NomeUsuario.ToString()} foi cadastrado com sucesso");
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return NotFound($"Não foi possível cadastrar o usuário... Motivo ==>> {ex.Message}");
            }
        }

        /// <summary>
        /// Faz a modificação dos atributos de um usuário específico.
        /// </summary>
        /// <param name="id">Armazena o identificador único do usuário</param>
        /// <param name="usuario">Armazena o objeto do usuário e compara com o vigorante que será modificado</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuario)
        {
            Usuario usuario1 = banco.GetById(id);
            if (usuario1 != null)
            {
                try
                {
                    banco.Put(id,usuario);
                    return Ok(usuario);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return NotFound("O usuário não consta no sistema..");
            }
        }

        /// <summary>
        /// Remove um usuário do sistema
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Usuario usuario = banco.GetById(id);
            if (usuario != null)
            {
                try
                {
                    banco.Deletar(id);
                    return Ok($"O usuário {usuario.NomeUsuario.ToString()} foi deletado com sucesso");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return NotFound("Usuário não encontrado");
            }
        }
    }
}