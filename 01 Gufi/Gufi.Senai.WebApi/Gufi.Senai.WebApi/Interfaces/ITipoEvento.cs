using Gufi.Senai.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.Senai.WebApi.Interfaces
{
    interface ITipoEvento
    {
        List<TipoEvento> Listar();

        TipoEvento Cadastrar(TipoEvento tipo);

        TipoEvento Atualizar(int id, TipoEvento tipo);

        TipoEvento Deletar(int id);

        TipoEvento BuscarPorId(int id);
    }
}
