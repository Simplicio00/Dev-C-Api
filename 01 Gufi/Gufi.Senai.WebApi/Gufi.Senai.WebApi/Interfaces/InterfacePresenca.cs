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
		void Aprovacao(string aprovacao, Presenca presenca);
	}
}
