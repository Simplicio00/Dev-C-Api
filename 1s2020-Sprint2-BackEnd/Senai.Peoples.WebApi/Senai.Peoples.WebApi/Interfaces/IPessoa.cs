using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IPessoa
    {
        List<PessoaDomain> Listar();

        PessoaDomain Post(PessoaDomain pessoa);

        PessoaDomain BuscarPorId(int id);

        PessoaDomain Atualizar(int id, PessoaDomain pessoa);

        PessoaDomain Delete(int id);

    }
}
