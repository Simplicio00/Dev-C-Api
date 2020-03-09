using Senai.DatabaseFirst.WebApi.Domains;
using Senai.DatabaseFirst.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.DatabaseFirst.WebApi.Repository
{
    class EstudiosRepository : IEstudioRepository
    {

        InlockContext context = new InlockContext();

        public Estudios Cadastrar(Estudios estudio)
        {
             context.Estudios.Add(estudio);
             context.SaveChanges();
            return estudio;
        }

        public Estudios getId(int id)
        {
            return context.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public List<Estudios> Listar()
        {
            return context.Estudios.ToList();
        }


    }
}
