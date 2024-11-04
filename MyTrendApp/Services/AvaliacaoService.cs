using Microsoft.EntityFrameworkCore;
using MyTrendApp.Data;
using MyTrendApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly ApplicationDbContext _context;

        public AvaliacaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Avaliacao>> GetAllAvaliacoesAsync()
        {
            return await _context.Avaliacoes.ToListAsync();
        }

        public async Task<Avaliacao?> GetAvaliacaoByIdAsync(int id)
        {
            return await _context.Avaliacoes.FindAsync(id);
        }

        public async Task<Avaliacao> CreateAvaliacaoAsync(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
            return avaliacao;
        }

        public async Task UpdateAvaliacaoAsync(int id, Avaliacao avaliacao)
        {
            var avaliacaoExistente = await _context.Avaliacoes.FindAsync(id);
            if (avaliacaoExistente != null)
            {
                // Atualizar as propriedades reais da avaliação existente
                avaliacaoExistente.Nota = avaliacao.Nota;
                avaliacaoExistente.Comentario = avaliacao.Comentario;

                await _context.SaveChangesAsync();
            }
        }

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
