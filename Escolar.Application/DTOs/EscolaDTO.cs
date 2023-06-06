using System.ComponentModel.DataAnnotations;

namespace Escolar.Application.DTOs
{
    public class EscolaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da escola")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o nome da imagem")]
        [MinLength(5)]
        [MaxLength(250)]
        public string ImagemUrl { get; set; }
    }
}
