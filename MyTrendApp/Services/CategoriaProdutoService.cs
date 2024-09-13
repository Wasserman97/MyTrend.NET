using Microsoft.EntityFrameworkCore;
using MyTrendApp.Data;
using MyTrendApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    /// <summary>
    /// Serviço para gerenciar categorias de produtos.
    /// </summary>
    public class CategoriaProdutoService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public CategoriaProdutoService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todas as categorias de produtos.
        /// </summary>
        /// <returns>Lista de categorias de produtos.</returns>
        public async Task<IEnumerable<CategoriaProduto>> GetAllCategoriasAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        /// <summary>
        /// Obtém uma categoria de produto pelo seu ID.
        /// </summary>
        /// <param name="id">ID da categoria de produto.</param>
        /// <returns>Categoria de produto correspondente ao ID.</returns>
        public async Task<CategoriaProduto> GetCategoriaByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        /// <summary>
        /// Cria uma nova categoria de produto.
        /// </summary>
        /// <param name="categoria">Objeto categoria de produto a ser criado.</param>
        public async Task<CategoriaProduto> CreateCategoriaAsync(CategoriaProduto categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        /// <summary>
        /// Atualiza uma categoria de produto existente.
        /// </summary>
        /// <param name="categoria">Objeto categoria de produto com dados atualizados.</param>
        public async Task UpdateCategoriaAsync(CategoriaProduto categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove uma categoria de produto pelo seu ID.
        /// </summary>
        /// <param name="id">ID da categoria de produto a ser removida.</param>
        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return false;
            }
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
