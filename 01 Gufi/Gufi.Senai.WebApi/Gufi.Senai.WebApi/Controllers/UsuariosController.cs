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

        
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                banco.Post(usuario);
                var msg = string.Format($"Usuário cadastrado com sucesso / {usuario}");
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return NotFound($"Não foi possível cadastrar o usuário ==>> {ex.Message}");
            }
        }

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
                return NotFound("O usuário em questão não existe");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Usuario usuario = banco.GetById(id);
            if (usuario != null)
            {
                try
                {
                    banco.Deletar(id);
                    return Ok("O usuário foi deletado com sucesso");
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