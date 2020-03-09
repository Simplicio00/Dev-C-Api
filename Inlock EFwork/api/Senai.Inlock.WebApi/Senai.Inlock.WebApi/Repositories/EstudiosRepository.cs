using Microsoft.EntityFrameworkCore;
using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Repositories
{
    public class EstudiosRepository : EstudiosInterface
    {
        BancoContexto banco = new BancoContexto();

        public Estudios BuscarPorId(int id)
        {  
            return banco.Estudios.FirstOrDefault(a => a.IdEstudio == id);
        }

        public Estudios Cadastrar(Estudios estudios)
        {
            banco.Estudios.Add(estudios);
            banco.SaveChangesAsync();
            return estudios;
        }

        public List<Estudios> Listar()
        {
             return banco.Estudios.ToList();
        }

        public List<Estudios> ListarComJogos()
        {
            return banco.Estudios.Include(e => e.Jogos).ToList();
        }

        public Estudios Put(Estudios estudio, int id)
        {
            Estudios estudioBuscado = banco.Estudios.First(es => es.IdEstudio == id);

            estudioBuscado.NomeEstudio = estudio.NomeEstudio;
            banco.Estudios.Update(estudioBuscado);
            banco.SaveChanges();
            return estudioBuscado;
        }
    }
}
