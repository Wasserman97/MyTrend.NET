using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyTrendApp.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public string Descricao { get; set; }

        [Required]
        public int CategoriaProdutoId { get; set; }

        [Required]
        public int CorId { get; set; }

        // Navegação
        public CategoriaProduto CategoriaProduto { get; set; }
        public Cor Cor { get; set; }
    }
}
