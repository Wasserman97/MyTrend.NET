using Microsoft.EntityFrameworkCore;
using MyTrendApp.Data;
using MyTrendApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    /// <summary>
    /// Serviço para gerenciar cores.
    /// </summary>
    public class CorService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public CorService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todas as cores.
        /// </summary>
        /// <returns>Lista de cores.</returns>
        public async Task<IEnumerable<Cor>> GetAllCoresAsync()
        {
            return await _context.Cores.ToListAsync();
        }

        /// <summary>
        /// Obtém uma cor pelo seu ID.
        /// </summary>
        /// <param name="id">ID da cor.</param>
        /// <returns>Cor correspondente ao ID.</returns>
        public async Task<Cor> GetCorByIdAsync(int id)
        {
            return await _context.Cores.FindAsync(id);
        }

        /// <summary>
        /// Cria uma nova cor.
        /// </summary>
        /// <param name="cor">Objeto cor a ser criado.</param>
        public async Task<Cor> CreateCorAsync(Cor cor)
        {
            _context.Cores.Add(cor);
            await _context.SaveChangesAsync();
            return cor;
        }

        /// <summary>
        /// Atualiza uma cor existente.
        /// </summary>
        /// <param name="cor">Objeto cor com dados atualizados.</param>
        public async Task UpdateCorAsync(Cor cor)
        {
            _context.Cores.Update(cor);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove uma cor pelo seu ID.
        /// </summary>
        /// <param name="id">ID da cor a ser removida.</param>
        public async Task<bool> DeleteCorAsync(int id)
        {
            var cor = await _context.Cores.FindAsync(id);
            if (cor == null)
            {
                return false;
            }
            _context.Cores.Remove(cor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
