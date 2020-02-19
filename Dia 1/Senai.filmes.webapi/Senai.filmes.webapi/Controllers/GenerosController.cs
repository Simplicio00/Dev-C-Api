using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.filmes.webapi.Domains;
using Senai.filmes.webapi.Interfaces;
using Senai.filmes.webapi.Repositories;

namespace Senai.filmes.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private IGeneroDomain dominio { get; set; }

        public GenerosController()
        {
            dominio = new GeneroRepository();
        }





        [HttpGet]
        public IEnumerable<GenerosDomain> Get()
        {
            return dominio.ListarGeneros();
        }


        [HttpPost]
        public IActionResult Post(GenerosDomain generosDomain)
        {
            if (generosDomain.Nome.Length == 0)
            {
                string mensagem = "Erro, não foi possível inserir (Valor não nulo requerido).";
                return BadRequest(mensagem);
            }
            try
            {
                dominio.Post(generosDomain);
            }
            catch (Exception ex)
            {
                string.Format($"O erro {ex.Message.ToString()} foi identificado");
            }

            return Ok(dominio.ListarGeneros());
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            dominio.Delete(id);
            return Ok(dominio.ListarGeneros());
        }




        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GenerosDomain generoBuscado = dominio.BuscarPorId(id);
            if (generoBuscado == null)
            {
                string erro = "O valor inserido é nulo";
                return NotFound(erro);
            }
            return StatusCode(200, generoBuscado);
        }


        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, GenerosDomain generosDomain)
        {
            GenerosDomain generoBuscado = dominio.BuscarPorId(id);
            if (generoBuscado == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Genero não encontrado",
                        erro = true
                    });
            }

            try
            {
                dominio.AtualizarIdUrl(id, generosDomain);
                return Ok(dominio.ListarGeneros());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            
        }



        [HttpPut]
        public IActionResult PutIdCorpo(GenerosDomain generosDomain)
        {
            GenerosDomain generoBuscado = dominio.BuscarPorId(generosDomain.IdGenero);
            if (generoBuscado != null)
            {
                try
                {
                    dominio.AtualizarCorpo(generosDomain);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);  
                }
            }
            return Ok(generosDomain);
        }

        



    }
}