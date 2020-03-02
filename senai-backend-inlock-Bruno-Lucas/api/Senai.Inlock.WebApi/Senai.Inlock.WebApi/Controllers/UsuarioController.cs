using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.Interfaces;
using Senai.Inlock.WebApi.Repositories;

namespace Senai.Inlock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuariosInterface usuarios;
        public UsuarioController()
        {
            usuarios =  new UsuariosRepository();
        }
        

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
    }
}