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
            throw new NotImplementedException();
        }

        public PessoaDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public PessoaDomain Delete(int id)
        {
            throw new NotImplementedException();
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
            return listaPessoas;
        }

        public PessoaDomain Post(PessoaDomain pessoa)
        {
            throw new NotImplementedException();
        }
    }
}
