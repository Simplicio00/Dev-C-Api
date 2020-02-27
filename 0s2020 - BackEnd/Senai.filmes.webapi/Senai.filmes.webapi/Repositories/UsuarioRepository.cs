using Senai.filmes.webapi.Domains;
using Senai.filmes.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.filmes.webapi.Repositories
{
    public class UsuarioRepository : IUsuarioDomain
    {
        private string bd = "Data Source=DEV101\\SQLEXPRESS; initial catalog=Filmes_manha; user Id=sa; pwd=sa@132";

        public UsuarioDomain BuscaPorEmailSenha(string email, string senha)
        {
            SqlConnection connection = new SqlConnection(bd);
            string querySelect = "select IdUsuario, Email, Senha, Permissao from Usuarios where Email = @Em and Senha = @Se";
            SqlCommand command = new SqlCommand(querySelect, connection);
            command.Parameters.AddWithValue("@Em",email);
            command.Parameters.AddWithValue("@Se",senha);

            connection.Open();
            SqlDataReader leitor = command.ExecuteReader();
            if (leitor.HasRows)
            {
                UsuarioDomain usuario = new UsuarioDomain();
                while (leitor.Read())
                {
                    usuario.IdUsuario = Convert.ToInt32(leitor[0]);
                    usuario.Email = Convert.ToString(leitor[1]);
                    usuario.Senha = Convert.ToString(leitor[2]);
                    usuario.Permissao = Convert.ToString(leitor[3]);
                }
                return usuario;
            }
            return null;
            
        }
    }
}
