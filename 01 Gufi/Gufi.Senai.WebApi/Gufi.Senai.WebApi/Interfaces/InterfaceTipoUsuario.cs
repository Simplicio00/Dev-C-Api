using Gufi.Senai.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.Senai.WebApi.Interfaces
{
	interface InterfaceTipoUsuario
	{
		List<TipoUsuario> Get();

		TipoUsuario Post(TipoUsuario tipoUsuario);

		TipoUsuario Put(int id, TipoUsuario tipoUsuario);

		TipoUsuario Delete(int id);

		TipoUsuario GetById(int id);
	}
}
