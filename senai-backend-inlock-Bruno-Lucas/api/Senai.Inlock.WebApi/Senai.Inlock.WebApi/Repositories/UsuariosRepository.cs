using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Repositories
{
    public class UsuariosRepository : UsuariosInterface
    {
        private string banco = "Data Source=DEV101\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";




        // Comparação dos dados inseridos pela api com os do banco de dados

        public UsuariosDomain Comparar(string Email, string Senha)
        {
            SqlConnection conexao = new SqlConnection(banco);
            string query = $"select IdUsuario, Email, Senha, IdTipoUsuario from Usuarios where Email like '{Email}' AND Senha like '{Senha}'";
            SqlCommand sqlcomando = new SqlCommand(query, conexao);
            conexao.Open();
            SqlDataReader leitor;
            leitor = sqlcomando.ExecuteReader();
            if (leitor.HasRows)
            {
                UsuariosDomain usuario = new UsuariosDomain();
                while (leitor.Read())
                {
                    usuario.IdUsuario = Convert.ToInt32(leitor[0]);
                    usuario.Email = Convert.ToString(leitor[1]);
                    usuario.Senha = Convert.ToString(leitor[2]);
                    usuario.IdTipoUsuario = Convert.ToInt32(leitor[3]);
                    usuario.TiposUsuario = new TiposUsuarioDomain
                    {
                        IdTipoUsuario = Convert.ToInt32(leitor[3]),
                        Titulo = Convert.ToString(leitor[3])
                    };
                }
                conexao.Close();
                return usuario;
            }
            return null;
        }




        // Listagem de usuários


        public List<UsuariosDomain> Listar()
        {
            List<UsuariosDomain> listarPessoas = new List<UsuariosDomain>();
            SqlConnection conexao = new SqlConnection(banco);
            var query = "select IdUsuario, Email, Senha, TiposUsuario.Titulo from Usuarios " +
                "inner join TiposUsuario on TiposUsuario.IdTipoUsuario = Usuarios.IdTipoUsuario";
            SqlCommand comando = new SqlCommand(query, conexao);
            conexao.Open();
            SqlDataReader leitor;
            leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                UsuariosDomain usuarios = new UsuariosDomain
                {
                    IdUsuario = Convert.ToInt32(leitor[0]),
                    Email = Convert.ToString(leitor[1]),
                    Senha = Convert.ToString(leitor[2]),
                    TiposUsuario = new TiposUsuarioDomain
                    {
                        IdTipoUsuario = Convert.ToInt32(leitor[0]),
                        Titulo = Convert.ToString(leitor[1])
                    }
                };
                listarPessoas.Add(usuarios);
            }
            conexao.Close();
            return listarPessoas;
        }
    }
}
