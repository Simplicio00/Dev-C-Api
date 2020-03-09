﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.CodeFirst.WebApi.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdJogo { get; set; }

        [Column(TypeName ="varchar(100)")]
        [Required(ErrorMessage ="O nome do jogo é obrigatório")]
        public string NomeJogo { get; set; }

        [Column(TypeName ="text")]
        [Required(ErrorMessage ="A descrição é obrigatória")]
        public string Descricao { get; set; }

        [Column(TypeName ="DATE")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="A data de lançamento é obrigatória")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName ="decimal (18,2)")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }
        
        [Required(ErrorMessage ="O estúdio do jogo é obrigatório")]
        public int IdEstudio { get; set; }
        [ForeignKey("IdEstudio")]
        public Estudios Estudio { get; set; }
    }
}
