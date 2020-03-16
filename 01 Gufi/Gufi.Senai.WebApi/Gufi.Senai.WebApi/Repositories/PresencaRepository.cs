using Gufi.Senai.WebApi.Domains;
using Gufi.Senai.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.Senai.WebApi.Repositories
{
	public class PresencaRepository : InterfacePresenca
	{
		GufiContext banco = new GufiContext();

		public void Aprovacao(string aprovacao, Presenca presenca)
		{
			throw new NotImplementedException();
		}

		public List<Presenca> Get()
		{
			try
			{
				return banco.Presenca.ToList();
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
