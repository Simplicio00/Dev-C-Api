using Senai.DatabaseFirst.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.DatabaseFirst.WebApi.Interfaces
{
    interface IEstudioRepository

    {
        List<Estudios> Listar();

        Estudios getId(int id);

        Estudios Cadastrar(Estudios estudio);
    }
}
