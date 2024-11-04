using Microsoft.EntityFrameworkCore;
using MyTrendApp.Data;
using MyTrendApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    /// <summary>
    /// Serviço para gerenciar perfis de usuário.
    /// </summary>
    public class PerfilUsuarioService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public PerfilUsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todos os perfis de usuário.
        /// </summary>
        /// <returns>Lista de perfis de usuário.</returns>
        public async Task<IEnumerable<PerfilUsuario>> GetAllPerfisAsync()
        {
            return await _context.Perfis.ToListAsync();
        }

        /// <summary>
        /// Obtém um perfil de usuário pelo seu ID.
        /// </summary>
        /// <param name="id">ID do perfil de usuário.</param>
        /// <returns>Perfil de usuário correspondente ao ID.</returns>
        public async Task<PerfilUsuario> GetPerfilByIdAsync(int id)
        {
            return await _context.Perfis.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo perfil de usuário.
        /// </summary>
        /// <param name="perfil">Objeto perfil de usuário a ser criado.</param>
        public async Task<PerfilUsuario> CreatePerfilAsync(PerfilUsuario perfil)
        {
            _context.Perfis.Add(perfil);
            await _context.SaveChangesAsync();
            return perfil;
        }

        /// <summary>
        /// Atualiza um perfil de usuário existente.
        /// </summary>
        /// <param name="perfil">Objeto perfil de usuário com dados atualizados.</param>
        public async Task UpdatePerfilAsync(PerfilUsuario perfil)
        {
            _context.Perfis.Update(perfil);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove um perfil de usuário pelo seu ID.
        /// </summary>
        /// <param name="id">ID do perfil de usuário a ser removido.</param>
        public async Task<bool> DeletePerfilAsync(int id)
        {
            var perfil = await _context.Perfis.FindAsync(id);
            if (perfil == null)
            {
                return false;
            }
            _context.Perfis.Remove(perfil);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
