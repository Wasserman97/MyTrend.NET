using System.ComponentModel.DataAnnotations;

namespace MyTrendApp.Models
{
    public class PerfilUsuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public string Estilo { get; set; } // Ex: Casual, Formal
        public string Biotipo { get; set; } // Ex: Magro, Musculoso
        public string Preferencias { get; set; } // Preferências gerais do usuário

        // Navegação
        public Usuario Usuario { get; set; }
    }
}
