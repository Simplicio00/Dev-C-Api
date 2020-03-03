using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Domains
{
    public class JogosDomain
    {
        public int IdJogo { get; set; }
        [Required(ErrorMessage = "O jogo precisa de um nome para ser cadastrado")]
        public string NomeJogo { get; set; }
        [Required(ErrorMessage = "Informe a descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe a data de lançamento na ordem ..../../..")]
        public DateTime DataLancamento { get; set; }
        [Required(ErrorMessage = "Informe o valor do jogo")]
        public string Valor { get; set; }
        [Required(ErrorMessage = "Apontar o id do estúdio é obrigatório")]
        public int IdEstudio { get; set; }
        public EstudiosDomain Estudios { get; set; }
    }
}
