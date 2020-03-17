using Gufi.Senai.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.Senai.WebApi.Interfaces
{
	interface InterfacePresenca
	{
		List<Presenca> Get();

		Presenca Post(Presenca presenca);

		Presenca Aprovacao(int id, Presenca presenca);

		List<Presenca> Confirmadas(string conf);


		//listar meus eventos
		List<Presenca> PresencaPorPessoa(int id);


	}
}
