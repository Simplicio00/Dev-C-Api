using System;
using System.Collections.Generic;

namespace Gufi.Senai.WebApi.Domains
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Evento = new HashSet<Evento>();
        }

        public int IdTipoEvento { get; set; }
        public string TituloTipoEvento { get; set; }

        public ICollection<Evento> Evento { get; set; }
    }
}
