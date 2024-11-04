using System.ComponentModel.DataAnnotations;

namespace MyTrendApp.Models
{
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public int Nota { get; set; } // Valor da avaliação, por exemplo, de 1 a 5

        public string Comentario { get; set; } // Comentário opcional sobre o produto

        // Navegação
        public Usuario Usuario { get; set; }
        public Produto Produto { get; set; }
    }
}
