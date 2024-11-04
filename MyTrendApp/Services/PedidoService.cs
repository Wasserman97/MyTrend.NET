using Microsoft.EntityFrameworkCore;
using MyTrendApp.Data;
using MyTrendApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    /// <summary>
    /// Serviço para gerenciar pedidos.
    /// </summary>
    public class PedidoService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public PedidoService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todos os pedidos.
        /// </summary>
        /// <returns>Lista de pedidos.</returns>
        public async Task<IEnumerable<Pedido>> GetAllPedidosAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        /// <summary>
        /// Obtém um pedido pelo seu ID.
        /// </summary>
        /// <param name="id">ID do pedido.</param>
        /// <returns>Pedido correspondente ao ID.</returns>
        public async Task<Pedido> GetPedidoByIdAsync(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo pedido.
        /// </summary>
        /// <param name="pedido">Objeto pedido a ser criado.</param>
        public async Task<Pedido> CreatePedidoAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        /// <summary>
        /// Atualiza um pedido existente.
        /// </summary>
        /// <param name="pedido">Objeto pedido com dados atualizados.</param>
        public async Task UpdatePedidoAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove um pedido pelo seu ID.
        /// </summary>
        /// <param name="id">ID do pedido a ser removido.</param>
        public async Task<bool> DeletePedidoAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return false;
            }
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
