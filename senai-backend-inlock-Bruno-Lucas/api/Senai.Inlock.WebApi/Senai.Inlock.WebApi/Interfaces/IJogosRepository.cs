using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Interfaces
{
    interface IJogosRepository
    {
        List<JogosDomain> Get();

        void Post(JogosDomain Filme);

        JogosDomain Delete(int id);

        JogosDomain BuscarPorId(int id);

        List<JogosDomain> ListarPorEstudio(int id);
    }
}
