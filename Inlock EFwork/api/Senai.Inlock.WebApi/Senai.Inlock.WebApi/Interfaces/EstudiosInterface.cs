using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Interfaces
{
	interface EstudiosInterface
	{
		 List<Estudios> Listar();
		 Estudios BuscarPorId(int id);
		 Estudios Cadastrar(Estudios estudios);

		List<Estudios> ListarComJogos();

        Estudios Put(Estudios estudio, int id);

	}
}
