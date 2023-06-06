using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escolar.Application.DTOs
{
    public class AlunoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Mae { get; set; }

        [Required(ErrorMessage = "Informe a série")]
        public int Serie { get; set; }

        [MaxLength(250)]
        public string ImagemUrl { get; set; }

        [Required(ErrorMessage = "O exAluno é obrigatório")]
        public int ExAluno { get; set; }

        public int EscolaId { get; set; }
    }
}
