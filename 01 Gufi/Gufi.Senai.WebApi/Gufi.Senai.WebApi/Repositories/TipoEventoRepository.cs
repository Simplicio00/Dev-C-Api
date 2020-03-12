using Gufi.Senai.WebApi.Domains;
using Gufi.Senai.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.Senai.WebApi.Repositories
{
    public class TipoEventoRepository : ITipoEvento
    {
        GufiContext banco = new GufiContext();

        public TipoEvento Atualizar(int id, TipoEvento tipo)
        {
            try
            {
                TipoEvento tipoEvento = banco.TipoEvento.FirstOrDefault(a => a.IdTipoEvento == id);
                tipoEvento.TituloTipoEvento = tipo.TituloTipoEvento;
                banco.Update(tipoEvento);
                banco.SaveChanges();
                return tipoEvento;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public TipoEvento BuscarPorId(int id)
        {
            try
            {
              return banco.TipoEvento.First(a => a.IdTipoEvento == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TipoEvento Cadastrar(TipoEvento tipo)
        {
            try
            {
                banco.TipoEvento.Add(tipo);
                banco.SaveChanges();
                return tipo;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TipoEvento Deletar(int id)
        {
            try
            {
                TipoEvento Objeto = banco.TipoEvento.First(a => a.IdTipoEvento == id);
                banco.Remove(Objeto);
                banco.SaveChanges();
                return Objeto;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<TipoEvento> Listar()
        {
            try
            {
                return banco.TipoEvento.ToList();

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
