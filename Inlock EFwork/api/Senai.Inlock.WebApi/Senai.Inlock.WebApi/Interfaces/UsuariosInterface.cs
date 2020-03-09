using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Interfaces
{
    interface UsuariosInterface
    {
        Usuarios Comparar(string Email, string Senha);

        List<Usuarios> Listar();

        Usuarios Cadastrar(Usuarios usuarios);

        Usuarios Atualizar(Usuarios usuario,int id);

    }
}
