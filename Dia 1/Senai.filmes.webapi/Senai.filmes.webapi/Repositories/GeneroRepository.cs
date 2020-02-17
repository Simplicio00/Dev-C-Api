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

		private string bd = "Data Source=DEV101\\SQLEXPRESS; initial catalog=Filmes_manha; user Id=sa; pwd=sa@132"; 
		// ou integrated security - em caso de não ter autenticação..

		public List<GenerosDomain> ListarGeneros()
		{
			List<GenerosDomain> Generos = new List<GenerosDomain>();
			
			using (SqlConnection connect = new SqlConnection(bd))
			{
				string query = "SELECT IdGenero, Nome FROM Generos";
				connect.Open();

				SqlDataReader reader;

				using (SqlCommand command = new SqlCommand(query,connect))
				{
					reader = command.ExecuteReader();

					while (reader.Read())
					{
						GenerosDomain generos = new GenerosDomain
						{
							IdGenero = Convert.ToInt32(reader[0]),
							Nome = reader["Nome"].ToString()
						};

						Generos.Add(generos);
					}
				}
			}

			return Generos;
		}
	}
}