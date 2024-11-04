using Microsoft.AspNetCore.Mvc;
using MyTrendApp.Models;
using MyTrendApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacoesController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAvaliacaoService _avaliacaoService;

        // Construtor único com ambas as dependências injetadas
        public AvaliacoesController(IAvaliacaoService avaliacaoService, IAuthService authService)
        {
            _avaliacaoService = avaliacaoService;
            _authService = authService;
        }

        [HttpGet("secure/{id}")]
        public async Task<ActionResult<Avaliacao>> AuthenticateAndGetAvaliacao(int id, string username, string password)
        {
            var isAuthenticated = await _authService.AuthenticateAsync(username, password);
            if (!isAuthenticated)
            {
                return Unauthorized("Authentication failed.");
            }

            var avaliacao = await _avaliacaoService.GetAvaliacaoByIdAsync(id);
            return avaliacao == null ? NotFound() : Ok(avaliacao);
        }

        // GET: api/avaliacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacoes()
        {
            var avaliacoes = await _avaliacaoService.GetAllAvaliacoesAsync();
            return Ok(avaliacoes);
        }

        // GET: api/avaliacoes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> GetAvaliacao(int id)
        {
            var avaliacao = await _avaliacaoService.GetAvaliacaoByIdAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            return Ok(avaliacao);
        }

        // POST: api/avaliacoes
        [HttpPost]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao(Avaliacao avaliacao)
        {
            var createdAvaliacao = await _avaliacaoService.CreateAvaliacaoAsync(avaliacao);
            return CreatedAtAction(nameof(GetAvaliacao), new { id = createdAvaliacao.Id }, createdAvaliacao);
        }

        // PUT: api/avaliacoes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvaliacao(int id, Avaliacao avaliacao)
        {
            if (id != avaliacao.Id)
            {
                return BadRequest();
            }
            await _avaliacaoService.UpdateAvaliacaoAsync(id, avaliacao); // Corrigido para passar ambos os parâmetros
            return NoContent();
        }

        // DELETE: api/avaliacoes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacao(int id)
        {
            var exists = await _avaliacaoService.DeleteAvaliacaoAsync(id);
            if (!exists)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
