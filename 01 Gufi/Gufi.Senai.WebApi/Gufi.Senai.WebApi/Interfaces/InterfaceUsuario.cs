using Gufi.Senai.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.Senai.WebApi.Interfaces
{
	interface InterfaceUsuario
	{
		List<Usuario> Get();

		Usuario GetById(int id);

		Usuario Put(int id, Usuario usuario);

		Usuario Post(Usuario usuario);

		Usuario Comparar(string Email, string Senha);

		void Deletar(int id);

	}
}
