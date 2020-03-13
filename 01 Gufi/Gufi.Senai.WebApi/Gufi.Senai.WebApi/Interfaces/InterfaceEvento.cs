using Gufi.Senai.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.Senai.WebApi.Interfaces
{
	interface InterfaceEvento
	{
		List<Evento> Get();
		Evento Cadastrar(Evento evento);
		Evento Put(int id, Evento evento);
		Evento Delete(int id);
		Evento BuscaPeloId(int id);

		//listar meus eventos

		//Convidar outros usuários

		//Inscrição em evento
	}
}
