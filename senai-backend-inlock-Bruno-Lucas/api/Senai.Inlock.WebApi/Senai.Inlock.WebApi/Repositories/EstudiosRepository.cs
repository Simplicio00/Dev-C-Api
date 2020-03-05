using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Repositories
{
	public class EstudiosRepository : EstudiosInterface
	{
        private string banco = "Data Source=LUCASSOLIVEIRA\\SQLEXPRESS; initial catalog=InLock_Games_Manha; integrated security=true";


		private IJogosRepository jogos;

        public List<EstudiosDomain> Listar()
		{
			List<EstudiosDomain> lista = new List<EstudiosDomain>();
			SqlConnection conexao = new SqlConnection(banco);
			var query = "SELECT IdEstudio, NomeEstudio FROM Estudios ";
			SqlCommand command = new SqlCommand(query,conexao);
			conexao.Open();
			SqlDataReader leitor;
			leitor = command.ExecuteReader();
			while (leitor.Read())
			{
				EstudiosDomain estudios = new EstudiosDomain
				{
					IdEstudio = Convert.ToInt32(leitor[0]),
					NomeEstudio = Convert.ToString(leitor[1]),
				};
				lista.Add(estudios);
			}
			conexao.Close();
			return lista;
		}




		public EstudiosDomain BuscarPorId(int id)
		{
			SqlConnection connection = new SqlConnection(banco);
			string query = $"select IdEstudio, NomeEstudio from Estudios where IdEstudio like {id}";
			SqlCommand command = new SqlCommand(query, connection);
			connection.Open();
			SqlDataReader leitor = command.ExecuteReader();
			if (leitor.Read())
			{
				
					EstudiosDomain estudios = new EstudiosDomain
					{
						IdEstudio = Convert.ToInt32(leitor[0]),
						NomeEstudio = Convert.ToString(leitor[1])
					};
					connection.Close();
					return estudios;
			}
			return null;
		}

		public EstudiosDomain Cadastrar(EstudiosDomain estudios)
		{
			SqlConnection connection = new SqlConnection(banco);
			string query = $"insert into Estudios(NomeEstudio)values('{estudios}')";
			SqlCommand command = new SqlCommand(query, connection);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
			return estudios;
		}

		public List<EstudiosDomain> ListarComJogos()
		{
			List<EstudiosDomain> estudios = new List<EstudiosDomain>();
			SqlConnection connection = new SqlConnection(banco);
			var query = "SELECT E.IdEstudio, E.NomeEstudio FROM Estudios E";
			SqlCommand command = new SqlCommand(query,connection);
			connection.Open();
			SqlDataReader leitor;
			leitor = command.ExecuteReader();
			while (leitor.Read())
			{
				EstudiosDomain estudios1 = new EstudiosDomain
				{
					IdEstudio = Convert.ToInt32(leitor["IdEstudio"]),
					NomeEstudio = leitor["NomeEstudio"].ToString(),
					Jogos = jogos.ListarPorEstudio(Convert.ToInt32(leitor["IdEstudio"]))
				};
				estudios.Add(estudios1);
			}
			connection.Close();
			return estudios;
		}
	}
}
