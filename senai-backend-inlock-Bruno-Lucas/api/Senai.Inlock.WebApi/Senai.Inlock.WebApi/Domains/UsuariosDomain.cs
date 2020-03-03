using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Domains
{
    public class UsuariosDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O mínimo necessário para inserir a senha é 3 caracteres.")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Informe o tipo do usuário (1 ou 2)")]
        public int IdTipoUsuario { get; set; }

        public TiposUsuarioDomain TiposUsuario { get; set; }
    }
}
