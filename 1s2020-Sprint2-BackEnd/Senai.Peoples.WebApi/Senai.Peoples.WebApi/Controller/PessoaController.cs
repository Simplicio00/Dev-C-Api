using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class PessoaController : ControllerBase
    {
        private IPessoa pessoa { get; set; }
        public PessoaController()
        {
            pessoa = new PessoaRepository();
        }


        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var lista = pessoa.Listar();

            if (lista != null)
            {
                return Ok(lista);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Cadastrar(PessoaDomain pessoa)
        {
            try
            {
                this.pessoa.Post(pessoa);
                return Ok(this.pessoa.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("{id}")]
        public IActionResult BuscaPeloId(int id)
        {
            try
            {
                return Ok(pessoa.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            PessoaDomain domain;
            domain = pessoa.BuscarPorId(id);

            if (domain != null)
            {
                pessoa.Delete(id);
                return Ok(pessoa.Listar());
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, PessoaDomain pessoa)
        {
            PessoaDomain domain;
            domain = this.pessoa.BuscarPorId(id);

            if (domain != null)
            {
                try
                {
                   this.pessoa.Atualizar(id, pessoa);
                   return Ok(this.pessoa.Listar());
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return BadRequest();
            }
        }


    }
}