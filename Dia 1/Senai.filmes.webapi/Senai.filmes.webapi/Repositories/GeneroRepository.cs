using Microsoft.AspNetCore.Mvc;
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

     


            //visualização
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









        //Cadastro

        public void Post(GenerosDomain generosDomain)
        {
            //string queryinsert = "Insert into generos(Nome) Values('"+generosDomain.Nome+"');"
            string comando = "insert into Generos(Nome)values(@Nome)";
           using (SqlConnection con = new SqlConnection(bd))
            {
                SqlCommand command = new SqlCommand(comando,con);
                command.Parameters.AddWithValue("@Nome",generosDomain.Nome);
                con.Open();
                command.ExecuteNonQuery();
            }
        }






        public GenerosDomain Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(bd))
            {
                string queryDeletar = "delete from Generos where IdGenero = @id";
                using (SqlCommand command = new SqlCommand(queryDeletar,connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                return null;
            }
        }







        public GenerosDomain GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(bd))
            {
                string queryBuscar = "Select IdGenero, Nome from generos";
                using (SqlCommand command = new SqlCommand(queryBuscar,connection))
                {
                    connection.Open();
                    SqlDataReader reader;
                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        GenerosDomain generosDomain = new GenerosDomain
                        {
                            IdGenero = Convert.ToInt32(reader["IdGenero"]),
                            Nome = reader["Nome"].ToString()
                        };

                        return generosDomain;
                    }

                    return null;
                }
            }
        }





        public void AtualizarIdUrl(int id, GenerosDomain generosDomain)
        {
            using (SqlConnection connection = new SqlConnection(bd))
            {
                string queryAtualizar = "update generos set Nome = @Nome where IDGenero = @Id";
                using (SqlCommand command = new SqlCommand(queryAtualizar, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nome", generosDomain.Nome);
                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }



        public void AtualizarCorpo(GenerosDomain generosDomain)
        {
            throw new NotImplementedException();
        }
    }
    }