using Senai.filmes.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.filmes.webapi.Interfaces
{
	public interface IGeneroDomain
	{
		/// <summary>
		/// Este  método lista todos os gêneros
		/// </summary>
		/// <returns>Retorna uma lista de generos </returns>

		List<GeneroDomain> ListarGeneros();
	}
}
