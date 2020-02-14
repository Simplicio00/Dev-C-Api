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
		public IEnumerable<GeneroDomain> Get()
		{
			return dominio.ListarGeneros();
		}


    }
}