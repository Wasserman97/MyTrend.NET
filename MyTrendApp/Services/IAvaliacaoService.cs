using MyTrendApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    public interface IAvaliacaoService
    {
        Task<IEnumerable<Avaliacao>> GetAllAvaliacoesAsync();
        Task<Avaliacao?> GetAvaliacaoByIdAsync(int id); // Nullable para lidar com retorno potencial de null
        Task<Avaliacao> CreateAvaliacaoAsync(Avaliacao avaliacao); // Retorna o objeto criado
        Task UpdateAvaliacaoAsync(int id, Avaliacao avaliacao); // Atualiza sem retornar bool, pois é um processo direto
        Task<bool> DeleteAvaliacaoAsync(int id); // Retorna bool para indicar sucesso/falha
    }
}
