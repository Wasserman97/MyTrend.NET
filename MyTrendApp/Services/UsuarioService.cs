using Microsoft.EntityFrameworkCore;
using MyTrendApp.Data;
using MyTrendApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    /// <summary>
    /// Serviço para gerenciar usuários.
    /// </summary>
    public class UsuarioService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        /// <returns>Lista de usuários.</returns>
        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        /// <summary>
        /// Obtém um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <returns>Usuário correspondente ao ID.</returns>
        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="usuario">Objeto usuário a ser criado.</param>
        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="usuario">Objeto usuário com dados atualizados.</param>
        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser removido.</param>
        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
