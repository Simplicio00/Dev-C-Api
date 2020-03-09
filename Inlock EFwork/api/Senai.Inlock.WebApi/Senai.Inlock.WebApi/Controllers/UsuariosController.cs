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
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private UsuariosInterface usuarios;
        public UsuariosController()
        {
            usuarios =  new UsuariosRepository();
        }

        /// <summary>
        /// Faz a listagem de todos os usuários cadastrados
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listagem()
        {
            var lista = usuarios.Listar();
            if (lista != null)
            {
                return Ok(lista);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Faz o cadastro de um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                usuarios.Cadastrar(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }


    }
}