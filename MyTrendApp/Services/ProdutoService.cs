using Microsoft.EntityFrameworkCore;
using MyTrendApp.Data;
using MyTrendApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    /// <summary>
    /// Serviço para gerenciar produtos.
    /// </summary>
    public class ProdutoService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public ProdutoService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todos os produtos.
        /// </summary>
        /// <returns>Lista de produtos.</returns>
        public async Task<IEnumerable<Produto>> GetAllProdutosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        /// <summary>
        /// Obtém um produto pelo seu ID.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <returns>Produto correspondente ao ID.</returns>
        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo produto.
        /// </summary>
        /// <param name="produto">Objeto produto a ser criado.</param>
        public async Task<Produto> CreateProdutoAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        /// <param name="produto">Objeto produto com dados atualizados.</param>
        public async Task UpdateProdutoAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove um produto pelo seu ID.
        /// </summary>
        /// <param name="id">ID do produto a ser removido.</param>
        public async Task<bool> DeleteProdutoAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return false;
            }
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
