using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyTrendApp.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Senha { get; set; } // Senha do usuário

        public ICollection<Avaliacao> Avaliacoes { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
        public PerfilUsuario Perfil { get; set; }
    }
}
