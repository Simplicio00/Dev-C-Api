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
            Usuarios usuarioBuscado = banco.Usuarios.FirstOrDefault(a => a.IdUsuario == id);
            usuarioBuscado.Email = usuario.Email;
            banco.Usuarios.Update(usuarioBuscado);
            banco.SaveChanges();
            return usuario;
        }

        public Usuarios BuscarPeloId(int id)
        {
            return banco.Usuarios.First(c => c.IdUsuario == id);
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
