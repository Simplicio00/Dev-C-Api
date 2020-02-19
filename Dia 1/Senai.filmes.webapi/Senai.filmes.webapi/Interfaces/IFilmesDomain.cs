using Senai.filmes.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.filmes.webapi.Interfaces
{
    interface IFilmesDomain
    {
        List<FilmeDomain> Lista();

        void Cadastro(FilmeDomain filme);

        FilmeDomain Apagar(int id);

        FilmeDomain BuscarPorId(int id);

        void Atualizar(int id, FilmeDomain filme);
    }
}
