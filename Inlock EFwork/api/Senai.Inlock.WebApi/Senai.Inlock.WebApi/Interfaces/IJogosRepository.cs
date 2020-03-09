using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Interfaces
{
    interface IJogosRepository
    {
        List<Jogos> Get();

        Jogos Post(Jogos Filme);

        Jogos Delete(Jogos jogo,int id);

        Jogos BuscarPorId(int id);

        List<Jogos> ListarPorEstudio(int id);
    }
}
