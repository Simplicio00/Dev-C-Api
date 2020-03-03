using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Domains
{
    public class EstudiosDomain
    {
        public int IdEstudio { get; set; }
        [Required(ErrorMessage = "O nome do estúdio é obrigatório")]
        public string NomeEstudio { get; set; }
    }
}
