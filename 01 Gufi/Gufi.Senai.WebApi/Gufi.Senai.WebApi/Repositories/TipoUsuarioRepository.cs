using Gufi.Senai.WebApi.Domains;
using Gufi.Senai.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.Senai.WebApi.Repositories
{
	public class TipoUsuarioRepository : InterfaceTipoUsuario
	{
		GufiContext banco = new GufiContext();

		public TipoUsuario Delete(int id)
		{
			TipoUsuario newtip = banco.TipoUsuario.Find(id);
			if (newtip != null)
			{
				banco.TipoUsuario.Remove(newtip);
				banco.SaveChanges();
				return newtip;
			}
			else
			{
				return null;
			}
		}

		public List<TipoUsuario> Get()
		{
			try
			{
				return banco.TipoUsuario.ToList();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public TipoUsuario GetById(int id)
		{
			try
			{
				return banco.TipoUsuario.Find(id);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public TipoUsuario Post(TipoUsuario tipoUsuario)
		{
			try
			{
				banco.TipoUsuario.Add(tipoUsuario);
				banco.SaveChanges();
				return tipoUsuario;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public TipoUsuario Put(int id, TipoUsuario tipoUsuario)
		{
			TipoUsuario tipo = banco.TipoUsuario.Find(id);
			if (tipo != null)
			{
				tipo.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
				banco.TipoUsuario.Update(tipo);
				banco.SaveChanges();
				return tipo;
			}
			else
			{
				return null;
			}
		}
	}
}
