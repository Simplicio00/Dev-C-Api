using Gufi.Senai.WebApi.Domains;
using Gufi.Senai.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.Senai.WebApi.Repositories
{
	public class PresencaRepository : InterfacePresenca
	{
		GufiContext banco = new GufiContext();

		public Presenca Aprovacao(int id, Presenca presenca)
		{
			Presenca presenca1 = banco.Presenca.FirstOrDefault(a => a.IdPresenca == id);
			if (presenca1 != null)
			{
				presenca1.Situacao = presenca.Situacao;
				banco.Update(presenca1);
				banco.SaveChanges();
				return presenca1;
			}
			else
			{
				return null;
			}

		}


		public List<Presenca> Confirmadas(string conf)
		{
			try
			{
				return banco.Presenca.Where(a => a.Situacao == conf).ToList();
			}
			catch (Exception)
			{
				return null;
			}
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

		public Presenca Post(Presenca presenca)
		{
				banco.Presenca.Add(presenca);
				banco.SaveChanges();
				return presenca;
		}


		public List<Presenca> PresencaPorPessoa(int id)
		{
			return banco.Presenca.Where(pessoa => pessoa.IdUsuario == id)
				.Include(a => a.IdEventoNavigation).ToList();
		}
	}
}
