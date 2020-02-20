using Senai.filmes.webapi.Domains;
using Senai.filmes.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.filmes.webapi.Repositories
{
    public class FilmeRepository : IFilmesDomain
    {
        //Acionando o banco de dados
        private string bd = "Data Source=DEV101\\SQLEXPRESS; initial catalog=Filmes_manha; user Id=sa; pwd=sa@132";
        //Acionando o banco de dados

        public FilmeDomain Apagar(int id)
        {
            using (SqlConnection connection = new SqlConnection(bd))
            {
                string queryDeletar = "delete from filmes where IdFilme = @Id";
                using (SqlCommand command = new SqlCommand(queryDeletar,connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Id",id);
                    command.ExecuteNonQuery();
                }
                return null;
            }
        }

        public void Atualizar(int id, FilmeDomain filme)
        {
            using (SqlConnection connection = new SqlConnection(bd))
            {
                string queryAtualizar = "update filmes set Titulo = @Nome where IdFilme = @Id";
                using (SqlCommand command = new SqlCommand(queryAtualizar,connection))
                {
                    command.Parameters.AddWithValue("@Id", filme.IdFilme);
                    command.Parameters.AddWithValue("@Nome", filme.Titulo);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(bd))
            {
                string queryBuscar = "select * from Filmes where IdFilme = @Id";
                using (SqlCommand command = new SqlCommand(queryBuscar,connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader leitor;
                    leitor = command.ExecuteReader();
                    if (leitor.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdGenero = Convert.ToInt32(leitor["IdFilme"]),
                            Titulo = leitor["Titulo"].ToString(),
                            Genero = new GenerosDomain
                            {
                                Nome = leitor["Nome"].ToString()
                            }
                        };
                        return filme;
                    }
                    return null;
                }
            }
        }



        public void Cadastro(FilmeDomain filme)
        {
            string queryBanco = "insert into Filmes(IdGenero,Titulo)values(@Id,@Nome);";
            using (SqlConnection connection = new SqlConnection(bd))
            {
                SqlCommand command = new SqlCommand(queryBanco, connection);
                command.Parameters.AddWithValue("@Id", filme.IdGenero);
                command.Parameters.AddWithValue("@Nome", filme.Titulo);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }




        public List<FilmeDomain> Lista()
        {
            List<FilmeDomain> filmeDomains = new List<FilmeDomain>();
            using (SqlConnection connect = new SqlConnection (bd))
            {
               string queryBanco = "select Filmes.IdFilme, Generos.IdGenero,  Filmes.Titulo, Generos.Nome from Filmes inner join Generos on Generos.IdGenero = Filmes.IdGenero";
                connect.Open();
                
                SqlDataReader leitor;

                using (SqlCommand command = new SqlCommand(queryBanco,connect))
                {
                    leitor = command.ExecuteReader();
                    while (leitor.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(leitor[0]),
                            Titulo = leitor[2].ToString(),
                            IdGenero = Convert.ToInt32(leitor[1]),
                            Genero = new GenerosDomain
                            {
                                IdGenero = Convert.ToInt32(leitor[1]),
                                Nome = leitor[3].ToString(),
                        }
                        };

                        filmeDomains.Add(filme);
                    }
                }
            }
            return filmeDomains; 
        }



    }
}
