using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyTrendApp.Models
{
    public class CategoriaProduto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        // Lista de produtos que pertencem a essa categoria
        public ICollection<Produto> Produtos { get; set; }
    }
}
