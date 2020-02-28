using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class PessoaDomain
    {
        public int IdPessoa { get; set; }
       // [Required(ErrorMessage = "O nome é obrigatório para o cadastro")]
        public string Nome { get; set; }
       // [Required(ErrorMessage = "O sobrenome  é um item obrigatório para o cadastro")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Informe o e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O campo senha precisa ter no mínimo 5 caracteres")]
        public string Senha { get; set; }
     //   [Required(ErrorMessage = "Informe o tipo de usuário pelo id")]
        public int IdTipoUsuario { get; set; }
        public TipoUsuarioDomain tipoUsuario { get; set;}
    }
}
