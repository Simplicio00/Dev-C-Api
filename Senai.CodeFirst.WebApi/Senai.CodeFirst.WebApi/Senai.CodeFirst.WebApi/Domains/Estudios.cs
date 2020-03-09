using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.CodeFirst.WebApi.Domains
{
    [Table("Estudio")]
    public class Estudios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstudio { get; set; }

        [Column(TypeName ="varchar(150)")]
        [Required(ErrorMessage ="O nome do estúdio é obrigatório")]
        public string NomeEstudio { get; set; }
        public List<Jogo> Jogo { get; set; }
    }
}
