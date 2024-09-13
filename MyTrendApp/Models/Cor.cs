using System.ComponentModel.DataAnnotations;

namespace MyTrendApp.Models
{
    public class Cor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; } // Nome da cor, ex: Vermelho, Azul

        public string CodigoHex { get; set; } // Código hexadecimal da cor
    }
}
