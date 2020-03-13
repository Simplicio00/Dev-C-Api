using Gufi.Senai.WebApi.Domains;
using Gufi.Senai.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.Senai.WebApi.Repositories
{
	public class UsuarioRepository : InterfaceUsuario
	{
		GufiContext banco = new GufiContext();

		public Usuario Comparar(string Email, string Senha)
		{
			try
			{
				return banco.Usuario.FirstOrDefault(a => a.Email == Email && a.Senha == Senha); 
			}
			catch (Exception)
			{
				return null;
			}
		}

		public void Deletar(int id)
		{
			Usuario usuario = banco.Usuario.First(a => a.IdUsuario == id);
			banco.Remove(usuario);
			banco.SaveChanges();
		}

		public List<Usuario> Get()
		{
			return banco.Usuario.ToList();
		}

		public Usuario GetById(int id)
		{
			try
			{
			return banco.Usuario.First(a => a.IdUsuario == id);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public Usuario Post(Usuario usuario)
		{
			try
			{
				 banco.Usuario.Add(usuario);
				banco.SaveChanges();
				return usuario;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public Usuario Put(int id, Usuario usuario)
		{
			try
			{
				Usuario usuario1 = banco.Usuario.Find(id);
				usuario1.NomeUsuario = usuario.NomeUsuario;
				usuario.Senha = usuario.Senha;
				banco.Usuario.Update(usuario1);
				return usuario1;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
