using Microsoft.EntityFrameworkCore;
using MyTrendApp.Data;
using MyTrendApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    /// <summary>
    /// Serviço para gerenciar feedbacks de usuários.
    /// </summary>
    public class FeedbackUsuarioService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public FeedbackUsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todos os feedbacks de usuários.
        /// </summary>
        /// <returns>Lista de feedbacks de usuários.</returns>
        public async Task<IEnumerable<FeedbackUsuario>> GetAllFeedbacksAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        /// <summary>
        /// Obtém um feedback de usuário pelo seu ID.
        /// </summary>
        /// <param name="id">ID do feedback de usuário.</param>
        /// <returns>Feedback de usuário correspondente ao ID.</returns>
        public async Task<FeedbackUsuario> GetFeedbackByIdAsync(int id)
        {
            return await _context.Feedbacks.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo feedback de usuário.
        /// </summary>
        /// <param name="feedback">Objeto feedback de usuário a ser criado.</param>
        public async Task<FeedbackUsuario> CreateFeedbackAsync(FeedbackUsuario feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        /// <summary>
        /// Atualiza um feedback de usuário existente.
        /// </summary>
        /// <param name="feedback">Objeto feedback de usuário com dados atualizados.</param>
        public async Task UpdateFeedbackAsync(FeedbackUsuario feedback)
        {
            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove um feedback de usuário pelo seu ID.
        /// </summary>
        /// <param name="id">ID do feedback de usuário a ser removido.</param>
        public async Task<bool> DeleteFeedbackAsync(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return false;
            }
            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
