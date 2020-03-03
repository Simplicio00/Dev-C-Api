using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Interfaces
{
	interface EstudiosInterface
	{
		 List<EstudiosDomain> Listar();
		 EstudiosDomain BuscarPorId(int id);
		 EstudiosDomain Cadastrar(EstudiosDomain estudios);

	}
}
