using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyTrendApp.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public DateTime DataPedido { get; set; }

        [Required]
        public decimal Total { get; set; }

        public ICollection<Produto> Produtos { get; set; } // Produtos no pedido

        // Navegação
        public Usuario Usuario { get; set; }
    }
}

