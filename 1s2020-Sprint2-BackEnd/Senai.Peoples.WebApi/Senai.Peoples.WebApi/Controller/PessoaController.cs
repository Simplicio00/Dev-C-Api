using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controller
{
    public class PessoaController : ControllerBase
    {
        PessoaRepository bd = new PessoaRepository();

        
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var lista = bd.Listar();
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