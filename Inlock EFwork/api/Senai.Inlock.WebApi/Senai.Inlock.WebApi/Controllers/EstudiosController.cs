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
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class EstudiosController : ControllerBase
	{
        EstudiosRepository estudios = new EstudiosRepository();

		/// <summary>
		/// Faz listagem dos estúdios 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Listagem()
		{
			var lista = estudios.Listar();
			if (lista != null)
			{
				return Ok(lista);
			}
			else
			{
				var msg = "A lista está vazia";
				return NotFound(msg);
			}
		}


		/// <summary>
		/// Consulta um estúdio específico pelo seu id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public IActionResult BuscarEstudioPorId(int id)
		{
			try
			{
				return Ok(estudios.BuscarPorId(id));
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}

		/// <summary>
		/// Faz o cadastro de um estúdio
		/// </summary>
		/// <param name="estudios"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Cadastrar(Estudios estudios)
		{
			try
			{
				this.estudios.Cadastrar(estudios);
				return Ok(estudios);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);			
			}
		}

		[HttpGet("List")]
		public IActionResult ListarComJogos()
		{
			var db = estudios.ListarComJogos();
			if (db != null)
			{
				return Ok(db);
			}
			else
			{
				return NotFound("A lista está vazia");
			}
		}


        [HttpPut("{id}")]
        public IActionResult Atualizacao(Estudios estudios, int id)
        {
            try
            {
                var result = this.estudios.Put(estudios, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
	}
}