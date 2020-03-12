using System;
using System.Collections.Generic;

namespace Gufi.Senai.WebApi.Domains
{
    public partial class Presenca
    {
        public int IdPresenca { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEvento { get; set; }
        public string Situacao { get; set; }

        public Evento IdEventoNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
