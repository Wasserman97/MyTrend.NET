using Microsoft.AspNetCore.Mvc;
using MyTrendApp.Models;
using MyTrendApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerfisController : ControllerBase
    {
        private readonly PerfilUsuarioService _perfilUsuarioService;

        public PerfisController(PerfilUsuarioService perfilUsuarioService)
        {
            _perfilUsuarioService = perfilUsuarioService;
        }

        // GET: api/perfis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerfilUsuario>>> GetPerfis()
        {
            var perfis = await _perfilUsuarioService.GetAllPerfisAsync();
            return Ok(perfis);
        }

        // GET: api/perfis/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PerfilUsuario>> GetPerfil(int id)
        {
            var perfil = await _perfilUsuarioService.GetPerfilByIdAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }
            return Ok(perfil);
        }

        // POST: api/perfis
        [HttpPost]
        public async Task<ActionResult<PerfilUsuario>> PostPerfil(PerfilUsuario perfil)
        {
            var createdPerfil = await _perfilUsuarioService.CreatePerfilAsync(perfil);
            return CreatedAtAction(nameof(GetPerfil), new { id = createdPerfil.Id }, createdPerfil);
        }

        // PUT: api/perfis/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil(int id, PerfilUsuario perfil)
        {
            if (id != perfil.Id)
            {
                return BadRequest();
            }
            await _perfilUsuarioService.UpdatePerfilAsync(perfil);
            return NoContent();
        }

        // DELETE: api/perfis/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfil(int id)
        {
            var exists = await _perfilUsuarioService.DeletePerfilAsync(id);
            if (!exists)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
