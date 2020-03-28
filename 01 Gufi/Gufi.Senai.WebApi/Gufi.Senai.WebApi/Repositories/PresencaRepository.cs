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



		public List<Presenca> Confirmadas()
		{
			try
			{
				return banco.Presenca.Where(a => a.Situacao == "confirmada").ToList();
			}
			catch (Exception)
			{
				return null;
			}
		}



		public void Convidar(Presenca convite)
		{
			convite.Situacao = "Não confirmada";
			banco.Presenca.Add(convite);
			banco.SaveChanges();
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
				presenca.Situacao = "Não confirmada";
				banco.Presenca.Add(presenca);
				banco.SaveChanges();
				return presenca;
		}


		public List<Presenca> PresencaPorPessoa(int id)
		{
			return banco.Presenca.Where(pessoa => pessoa.IdUsuario == id)
				.Include(a => a.IdEventoNavigation).ToList();
		}




		public void Aprovacao(int id, string presenca)
		{

			Presenca presenca1 = banco.Presenca.Include(p => p.IdUsuarioNavigation).Include(p => p.IdEventoNavigation).FirstOrDefault(a => a.IdPresenca == id);

			presenca1.Situacao = presenca;

			switch (presenca)
			{
				// Se for 1, a situação da presença será "Confirmada"
				case "1":
					presenca1.Situacao = "Confirmada";
					break;

				// Se for 0, a situação da presença será "Recusada"
				case "0":
					presenca1.Situacao = "Recusada";
					break;

				// Se for 2, a situação da presença será "Não confirmada"
				case "2":
					presenca1.Situacao = "Não confirmada";
					break;

				// Se for qualquer valor diferente de 0, 1 e 2, a situação da presença não será alterada
				default:
					presenca1.Situacao = presenca1.Situacao;
					break;
			}

			banco.Update(presenca1);
			banco.SaveChanges();
		}
	}
}
