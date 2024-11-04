using System.ComponentModel.DataAnnotations;

namespace MyTrendApp.Models
{
    public class FeedbackUsuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public string Feedback { get; set; } // Comentário ou feedback do usuário

        public DateTime DataFeedback { get; set; } // Data do feedback

        // Navegação
        public Usuario Usuario { get; set; }
    }
}
