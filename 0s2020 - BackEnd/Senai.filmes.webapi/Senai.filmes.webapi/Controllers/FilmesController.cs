using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.filmes.webapi.Domains;
using Senai.filmes.webapi.Repositories;

namespace Senai.filmes.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        FilmeRepository banco = new FilmeRepository();

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var lista = banco.Lista();
            return Ok(lista);
        }

        [HttpPost]
        public IActionResult CadastrarFilme(FilmeDomain filme)
        {
            if (filme.Titulo.Length == 0)
            {
                return BadRequest();
            }

            try
            {
                banco.Cadastro(filme);
            }
            catch (Exception ex)
            {
                string.Format(ex.Message.ToString());
            }

            return Ok(banco.Lista());

        }


        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            try
            {
                banco.Apagar(id);
            }
            catch (Exception ex)
            {
                string.Format(ex.Message.ToString());
            }

            return Ok(banco.Lista());
        }


        [HttpGet("{id}")]

        public IActionResult BuscarId(int id)
        {
            FilmeDomain filme;
            filme = banco.BuscarPorId(id);
            if (filme != null)
            {
                return Ok(filme);
            }
            else
            {
                return BadRequest();
            }
        }



        [HttpPut("{id}")]
        public IActionResult AlterarFilme(int id, FilmeDomain filme)
        {
            FilmeDomain fme;
            fme = banco.BuscarPorId(id);
            if (fme != null)
            {
                try
                {
                    banco.Atualizar(id, filme);
                    return Ok(banco.Lista());
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }
            }
            return BadRequest();
        }


        
    }
}