using System.ComponentModel.DataAnnotations;

namespace MyTrendApp.Models
{
    public class Roupa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        public int CorId { get; set; }

        // Navegação
        public Cor Cor { get; set; }
    }
}
