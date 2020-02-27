using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class PessoaRepository : IPessoa
    {
        private string bd = "Data Source=DEV101\\SQLEXPRESS; initial catalog=people_senai_bk; user Id=sa; pwd=sa@132";




        public PessoaDomain Atualizar(int id, PessoaDomain pessoa)
        {
            SqlConnection connection = new SqlConnection(bd);
            string query = "update Pessoas set Nome = @No, Sobrenome = @Sob where IdPessoa = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@No", pessoa.Nome);
            command.Parameters.AddWithValue("@Sob", pessoa.Sobrenome);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

            return null;
        }



        public PessoaDomain BuscarPorId(int id)
        {
            SqlConnection connection = new SqlConnection(bd);
            string query = "select IdPessoa, Nome, Sobrenome from Pessoas where IdPessoa = @Id";

            connection.Open();

            SqlCommand command = new SqlCommand(query,connection);
            SqlDataReader leitor;

            command.Parameters.AddWithValue("Id", id);
            leitor = command.ExecuteReader();
            if (leitor.Read())
            {
                PessoaDomain pessoa = new PessoaDomain
                {
                    IdPessoa = Convert.ToInt32(leitor[0]),
                    Nome = Convert.ToString(leitor[1]),
                    Sobrenome = Convert.ToString(leitor[2])
                };
                return pessoa;
            }
            connection.Close();
            return null;
        }

        public PessoaDomain BuscarPorNome(string nome)
        {
            SqlConnection connection = new SqlConnection(bd);
            string query = $"Select IdPessoa, Nome, Sobrenome from Pessoas where Nome like '%{nome}%'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader leitor;
            leitor = command.ExecuteReader();
            if (leitor.Read())
            {
                PessoaDomain pessoa = new PessoaDomain
                {
                    IdPessoa = Convert.ToInt32(leitor[0]),
                    Nome = Convert.ToString(leitor[1]),
                    Sobrenome = Convert.ToString(leitor[2])
                };
                return pessoa;
            }
            connection.Close();
            return null;
        }

        public PessoaDomain Delete(int id)
        {
            SqlConnection connection = new SqlConnection(bd);
            string query = "delete from Pessoas where IdPessoa = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return null;
        }



        public List<PessoaDomain> Listar()
        {
            List<PessoaDomain> listaPessoas = new List<PessoaDomain>();
            SqlConnection connect = new SqlConnection(bd);
            connect.Open();
            var queryBanco = "select IdPessoa, Nome, Sobrenome from Pessoas";
            SqlCommand sqlCommand = new SqlCommand(queryBanco, connect);

            SqlDataReader leitor;
            leitor = sqlCommand.ExecuteReader();

            while (leitor.Read())
            {
                PessoaDomain pessoas = new PessoaDomain
                {
                    IdPessoa = Convert.ToInt32(leitor[0]),
                    Nome = Convert.ToString(leitor[1]),
                    Sobrenome = Convert.ToString(leitor[2])
                };
                listaPessoas.Add(pessoas);
            }
            connect.Close();
            return listaPessoas;
        }



        public PessoaDomain Post(PessoaDomain pessoa)
        {
            string comando = "insert into Pessoas(Nome,Sobrenome)values(@va,@vb)";
            using (SqlConnection con = new SqlConnection(bd))
            {
                SqlCommand command = new SqlCommand(comando, con);
                command.Parameters.AddWithValue("@va", pessoa.Nome);
                command.Parameters.AddWithValue("@vb", pessoa.Sobrenome);

                con.Open();
                command.ExecuteNonQuery();
                return pessoa;
            }
        }
       
      
    }
}
