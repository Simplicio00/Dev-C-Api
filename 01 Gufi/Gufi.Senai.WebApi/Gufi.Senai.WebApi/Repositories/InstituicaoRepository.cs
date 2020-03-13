using Gufi.Senai.WebApi.Domains;
using Gufi.Senai.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.Senai.WebApi.Repositories
{
	public class InstituicaoRepository : InterfaceInstituicao
	{

		GufiContext banco = new GufiContext();

		public Instituicao BuscaPeloId(int id)
		{
			try
			{
				return banco.Instituicao.Find(id);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public Instituicao Cadastrar(Instituicao instituicao)
		{

			try
			{
				banco.Instituicao.Add(instituicao);
				banco.SaveChanges();
				return instituicao;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public Instituicao Delete(int id)
		{
			Instituicao instituicao = banco.Instituicao.Find(id);
			if (instituicao != null)
			{
				banco.Instituicao.Add(instituicao);
				banco.SaveChanges();
				return instituicao;
			}
			else
			{
				return null;
			}
		}

		public List<Instituicao> Get()
		{
			try
			{
				return banco.Instituicao.ToList();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public Instituicao Put(int id, Instituicao instituicao)
		{
			Instituicao instituicao1 = banco.Instituicao.First(a => a.IdInstituicao == id);
			if (instituicao1 != null)
			{
				instituicao1.NomeFantasia = instituicao.NomeFantasia;
				instituicao1.Cnpj = instituicao.Cnpj;
				instituicao1.Endereco = instituicao.Endereco;

				banco.Update(instituicao1);
				banco.SaveChanges();

				return instituicao1;
			}
			else
			{
				return null;
			}
		}
	}
}
