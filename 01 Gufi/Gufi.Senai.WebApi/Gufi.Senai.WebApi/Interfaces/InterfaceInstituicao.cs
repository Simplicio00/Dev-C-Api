using Gufi.Senai.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.Senai.WebApi.Interfaces
{
	interface InterfaceInstituicao
	{
		List<Instituicao> Get();
		Instituicao Cadastrar(Instituicao instituicao);
		Instituicao Put(int id, Instituicao instituicao);
		Instituicao Delete(int id);
		Instituicao BuscaPeloId(int id);
	}
}
