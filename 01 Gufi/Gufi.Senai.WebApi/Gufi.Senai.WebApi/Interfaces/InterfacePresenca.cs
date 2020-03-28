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

		void Aprovacao(int id, string presenca);

		List<Presenca> Confirmadas();


		//listar meus eventos
		List<Presenca> PresencaPorPessoa(int id);


		void Convidar(Presenca convite);


	}
}
