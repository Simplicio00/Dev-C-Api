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
    public class JogosRepository : IJogosRepository
    {
        BancoContexto banco = new BancoContexto();

        public Jogos BuscarPorId(int id)
        {
           return banco.Jogos.First(a => a.IdJogo == id);
        }

        public Jogos Delete(Jogos jogo,int id)
        {
            Jogos domain = banco.Jogos.FirstOrDefault(a => a.IdJogo == id);
            banco.Remove(jogo);
            return jogo;
        }

        public List<Jogos> Get()
        {
            return banco.Jogos.ToList();
        }

        public List<Jogos> ListarPorEstudio(int id)
        {
           var dc = banco.Jogos.Include(b => b.IdEstudioNavigation).Where(a => a.IdEstudio == id);
            return dc.ToList();

         //  return banco.Jogos.ToList().FindAll(j => j.IdEstudio == id);
        }

        public Jogos Post(Jogos Filme)
        {
            banco.Add(Filme);
            banco.SaveChanges();
            return Filme;
        }
    }
}
