using Senai.filmes.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.filmes.webapi.Interfaces
{
    interface IUsuarioDomain
    {
        UsuarioDomain BuscaPorEmailSenha(string email, string senha);
    }
}
