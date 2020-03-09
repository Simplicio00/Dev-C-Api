using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.DatabaseFirst.WebApi.Repository;

namespace Senai.DatabaseFirst.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class EstudiosController : ControllerBase
    {
        EstudiosRepository rep = new EstudiosRepository();

        [HttpGet]
        public IActionResult Get()
        {
            var lista = rep.Listar();

            if (lista.Count != 0)
            {
                return Ok(lista);
            }
            else
            {
                return NotFound("A lista está vazia");
            }
        }
    }
}