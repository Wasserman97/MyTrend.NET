using Microsoft.EntityFrameworkCore;
using MyTrendApp.Data;
using MyTrendApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    /// <summary>
    /// Serviço para gerenciar recomendações de looks.
    /// </summary>
    public class RecomendacaoLookService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public RecomendacaoLookService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todas as recomendações de looks.
        /// </summary>
        /// <returns>Lista de recomendações de looks.</returns>
        public async Task<IEnumerable<RecomendacaoLook>> GetAllRecomendacoesAsync()
        {
            return await _context.Recomendacoes.ToListAsync();
        }

        /// <summary>
        /// Obtém uma recomendação de look pelo seu ID.
        /// </summary>
        /// <param name="id">ID da recomendação de look.</param>
        /// <returns>Recomendação de look correspondente ao ID.</returns>
        public async Task<RecomendacaoLook> GetRecomendacaoByIdAsync(int id)
        {
            return await _context.Recomendacoes.FindAsync(id);
        }

        /// <summary>
        /// Cria uma nova recomendação de look.
        /// </summary>
        /// <param name="recomendacao">Objeto recomendação de look a ser criado.</param>
        public async Task<RecomendacaoLook> CreateRecomendacaoAsync(RecomendacaoLook recomendacao)
        {
            _context.Recomendacoes.Add(recomendacao);
            await _context.SaveChangesAsync();
            return recomendacao;
        }

        /// <summary>
        /// Atualiza uma recomendação de look existente.
        /// </summary>
        /// <param name="recomendacao">Objeto recomendação de look com dados atualizados.</param>
        public async Task UpdateRecomendacaoAsync(RecomendacaoLook recomendacao)
        {
            _context.Recomendacoes.Update(recomendacao);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove uma recomendação de look pelo seu ID.
        /// </summary>
        /// <param name="id">ID da recomendação de look a ser removida.</param>
        public async Task<bool> DeleteRecomendacaoAsync(int id)
        {
            var recomendacao = await _context.Recomendacoes.FindAsync(id);
            if (recomendacao == null)
            {
                return false;
            }
            _context.Recomendacoes.Remove(recomendacao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
