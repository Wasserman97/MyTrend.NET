using Microsoft.EntityFrameworkCore;
using MyTrendApp.Data;
using MyTrendApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    /// <summary>
    /// Serviço para gerenciar roupas.
    /// </summary>
    public class RoupaService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public RoupaService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todas as roupas.
        /// </summary>
        /// <returns>Lista de roupas.</returns>
        public async Task<IEnumerable<Roupa>> GetAllRoupasAsync()
        {
            return await _context.Roupas.ToListAsync();
        }

        /// <summary>
        /// Obtém uma roupa pelo seu ID.
        /// </summary>
        /// <param name="id">ID da roupa.</param>
        /// <returns>Roupa correspondente ao ID.</returns>
        public async Task<Roupa> GetRoupaByIdAsync(int id)
        {
            return await _context.Roupas.FindAsync(id);
        }

        /// <summary>
        /// Cria uma nova roupa.
        /// </summary>
        /// <param name="roupa">Objeto roupa a ser criado.</param>
        public async Task<Roupa> CreateRoupaAsync(Roupa roupa)
        {
            _context.Roupas.Add(roupa);
            await _context.SaveChangesAsync();
            return roupa;
        }

        /// <summary>
        /// Atualiza uma roupa existente.
        /// </summary>
        /// <param name="roupa">Objeto roupa com dados atualizados.</param>
        public async Task UpdateRoupaAsync(Roupa roupa)
        {
            _context.Roupas.Update(roupa);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove uma roupa pelo seu ID.
        /// </summary>
        /// <param name="id">ID da roupa a ser removida.</param>
        public async Task<bool> DeleteRoupaAsync(int id)
        {
            var roupa = await _context.Roupas.FindAsync(id);
            if (roupa == null)
            {
                return false;
            }
            _context.Roupas.Remove(roupa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
