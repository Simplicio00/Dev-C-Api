using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}