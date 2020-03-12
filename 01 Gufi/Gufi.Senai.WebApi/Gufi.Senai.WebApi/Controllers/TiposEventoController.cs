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
    public class TiposEventoController : ControllerBase
    {
        TipoEventoRepository banco = new TipoEventoRepository();

        [HttpGet]
        public IActionResult Get()
        {
            var lista = banco.Listar();
            if (lista.Count != 0)
            {
                return Ok(lista);
            }
            else
            {
                return NotFound("A lista está vazia");
            }
        }

        [HttpPost]

        public IActionResult Cadastrar(TipoEvento tipo)
        {
            try
            {
                banco.Cadastrar(tipo);
                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro na hora do cadastro... {ex.Message}");
            }
        }

        [HttpGet("{id}")]

        public IActionResult PorId(int id)
        {
            try
            {
                return Ok(banco.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return NotFound($"Ocorreu um erro ao consultar o id do usuário, {ex.Message}");
            }
        }


        [HttpPut("{id}")]

        public IActionResult Put(int id, TipoEvento tipo)
        {
            TipoEvento tipoEvento = banco.BuscarPorId(id);
            if (tipoEvento != null)
            {
                try
                {
                    return Ok(banco.Atualizar(id, tipo));
                }
                catch (Exception ex)
                {
                    return NotFound($"O tipo de evento inserido não foi encontrado ==>>> {ex.Message}");
                }
            }
            else
            {
                return NotFound("O tipo de evento não foi encontrado");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            TipoEvento tipo = banco.BuscarPorId(id);
            if (tipo != null)
            {
                banco.Deletar(id);
                return Ok(tipo);
            }
            else
            {
                return NotFound("Não é possível excluir");
            }
        }

    }
}