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
        BancoContexto banco = new BancoContexto();

        public Usuarios Atualizar(Usuarios usuario, int id)
        {
            banco.Usuarios.FirstOrDefault(a => a.IdUsuario == id);
            banco.Usuarios.Update(usuario);
            banco.SaveChanges();
            return usuario;
        }

        public Usuarios Cadastrar(Usuarios usuarios)
        {
            banco.Usuarios.Add(usuarios);
            banco.SaveChanges();
            return usuarios;
        }

        public Usuarios Comparar(string Email, string Senha)
        {
           return banco.Usuarios.FirstOrDefault(a => a.Email == Email && a.Senha == Senha);
        }

        public List<Usuarios> Listar()
        {
            return banco.Usuarios.ToList();
        }
    }
}
