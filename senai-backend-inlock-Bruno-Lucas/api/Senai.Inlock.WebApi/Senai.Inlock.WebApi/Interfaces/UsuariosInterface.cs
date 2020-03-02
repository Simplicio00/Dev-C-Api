using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Interfaces
{
    interface UsuariosInterface
    {
       UsuariosDomain Comparar(string Email, string Senha);

       List<UsuariosDomain> Listar();

    }
}
