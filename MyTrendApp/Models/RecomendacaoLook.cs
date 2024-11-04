using System.ComponentModel.DataAnnotations;

namespace MyTrendApp.Models
{
    public class RecomendacaoLook
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public string Look { get; set; } // Descrição ou identificador do look

        public string Comentarios { get; set; } // Comentários sobre a recomendação

        // Navegação
        public Usuario Usuario { get; set; }
    }
}
