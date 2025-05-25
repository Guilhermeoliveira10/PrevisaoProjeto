using System.ComponentModel.DataAnnotations;

namespace PrevisaoProjeto.DTOs
{
    public class PrevisaoRequestDto
    {
        [Required]
        [Range(18, 100)]
        public float Idade { get; set; }

        [Required]
        [Range(1000, 20000)]
        public float Salario { get; set; }
    }
}
