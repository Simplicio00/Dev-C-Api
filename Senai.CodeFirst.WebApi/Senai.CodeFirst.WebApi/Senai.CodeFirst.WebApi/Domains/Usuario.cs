using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.CodeFirst.WebApi.Domains
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        [Column(TypeName ="varchar(150)")]
        [Required(ErrorMessage ="O email do usuário é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Column(TypeName ="varchar(250)")]
        [Required(ErrorMessage ="A senha é obrigatória")]
        [DataType(DataType.Password)]
        [StringLength(30,MinimumLength = 5, ErrorMessage ="A senha deve conter no mínimo 5 caracteres")]
        public string Senha { get; set; }


        public int IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TiposUsuario TipoUsuario { get; set; }
    }
}
