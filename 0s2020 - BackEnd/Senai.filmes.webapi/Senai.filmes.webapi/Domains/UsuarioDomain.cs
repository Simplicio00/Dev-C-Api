using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.filmes.webapi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Informe a senha")]
        [StringLength(20, MinimumLength = 3, ErrorMessage ="O campo senha precisa ter no mínimo 3 caracteres")]
        public string Senha { get; set; }

        public string Permissao { get; set; }
    }
}
