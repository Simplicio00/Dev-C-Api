using Senai.filmes.webapi.Domains;
using Senai.filmes.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.filmes.webapi.Repositories
{
	public class GeneroRepository : IGeneroDomain
	{

		private string bd = "Data Source=DEV101\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=sa@132"; 
		// ou integrated security - em caso de não ter autenticação..

		public List<GeneroDomain> ListarGeneros()
		{
			List<GeneroDomain> Generos = new List<GeneroDomain>();
			
			using (SqlConnection connect = new SqlConnection(bd))
			{
				string query = "SELECT IdGenero, Nome FROM Genero";
				connect.Open();

				SqlDataReader reader;

				using (SqlCommand command = new SqlCommand(query,connect))
				{
					reader = command.ExecuteReader();

					while (reader.Read())
					{
						GeneroDomain genero = new GeneroDomain
						{
							IdGenero = Convert.ToInt32(reader[0]),
							Nome = reader["Nome"].ToString()
						};

						Generos.Add(genero);
					}
				}
			}

			return Generos;
		}
	}
}