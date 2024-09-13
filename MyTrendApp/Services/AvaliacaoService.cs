using Microsoft.EntityFrameworkCore;
using MyTrendApp.Data;
using MyTrendApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    /// <summary>
    /// Serviço para gerenciar avaliações.
    /// </summary>
    public class AvaliacaoService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public AvaliacaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todas as avaliações.
        /// </summary>
        /// <returns>Lista de avaliações.</returns>
        public async Task<IEnumerable<Avaliacao>> GetAllAvaliacoesAsync()
        {
            return await _context.Avaliacoes.ToListAsync();
        }

        /// <summary>
        /// Obtém uma avaliação pelo seu ID.
        /// </summary>
        /// <param name="id">ID da avaliação.</param>
        /// <returns>Avaliação correspondente ao ID.</returns>
        public async Task<Avaliacao> GetAvaliacaoByIdAsync(int id)
        {
            return await _context.Avaliacoes.FindAsync(id);
        }

        /// <summary>
        /// Cria uma nova avaliação.
        /// </summary>
        /// <param name="avaliacao">Objeto avaliação a ser criado.</param>
        public async Task<Avaliacao> CreateAvaliacaoAsync(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
            return avaliacao;
        }

        /// <summary>
        /// Atualiza uma avaliação existente.
        /// </summary>
        /// <param name="avaliacao">Objeto avaliação com dados atualizados.</param>
        public async Task UpdateAvaliacaoAsync(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Update(avaliacao);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove uma avaliação pelo seu ID.
        /// </summary>
        /// <param name="id">ID da avaliação a ser removida.</param>
        public async Task<bool> DeleteAvaliacaoAsync(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return false;
            }
            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
