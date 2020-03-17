using Gufi.Senai.WebApi.Domains;
using Gufi.Senai.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.Senai.WebApi.Repositories
{
	public class EventoRepository : InterfaceEvento
	{
		GufiContext banco = new GufiContext();

		public Evento BuscaPeloId(int id)
		{
			try
			{
				return banco.Evento.Find(id);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public Evento Cadastrar(Evento evento)
		{
			try
			{

				banco.Evento.Add(evento);
				banco.SaveChanges();
				return evento;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public Evento Delete(int id)
		{
			Evento evento = banco.Evento.Find(id);
			if (evento != null)
			{
				banco.Evento.Add(evento);
				banco.SaveChanges();
				return evento;
			}
			else
			{
				return null;
			}
		}

		public List<Evento> Get()
		{
				return banco.Evento.ToList();
		}

		

		public Evento Put(int id, Evento evento)
		{
			Evento evento1 = banco.Evento.First(a => a.IdEvento == id);
			if (evento1 != null)
			{
				evento1.NomeEvento = evento.NomeEvento;
				evento1.Descricao = evento.Descricao;
				evento1.AcessoLivre = evento.AcessoLivre;
				evento1.IdTipoEvento = evento.IdTipoEvento;
				evento1.Presenca = evento.Presenca;
				evento1.IdTipoEvento = evento.IdTipoEvento;
				evento1.IdInstituicao = evento.IdInstituicao;

				banco.Update(evento1);
				banco.SaveChanges();

				return evento1;
			}
			else
			{
				return null;
			}
		}
	}
}
