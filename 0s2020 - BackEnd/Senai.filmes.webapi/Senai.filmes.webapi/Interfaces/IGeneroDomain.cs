using Microsoft.AspNetCore.Mvc;
using Senai.filmes.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.filmes.webapi.Interfaces
{
	public interface IGeneroDomain
	{
		List<GenerosDomain> ListarGeneros();

        void Post(GenerosDomain generosDomain);
        
        GenerosDomain Delete(int id);

        GenerosDomain BuscarPorId(int id);

        void AtualizarCorpo(GenerosDomain generosDomain);

        void AtualizarIdUrl(int id, GenerosDomain generosDomain);
	}
}
