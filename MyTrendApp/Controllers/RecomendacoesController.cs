using Microsoft.AspNetCore.Mvc;
using MyTrendApp.Models;
using MyTrendApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecomendacoesController : ControllerBase
    {
        private readonly RecomendacaoLookService _recomendacaoLookService;

        public RecomendacoesController(RecomendacaoLookService recomendacaoLookService)
        {
            _recomendacaoLookService = recomendacaoLookService;
        }

        // GET: api/recomendacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecomendacaoLook>>> GetRecomendacoes()
        {
            var recomendacoes = await _recomendacaoLookService.GetAllRecomendacoesAsync();
            return Ok(recomendacoes);
        }

        // GET: api/recomendacoes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RecomendacaoLook>> GetRecomendacao(int id)
        {
            var recomendacao = await _recomendacaoLookService.GetRecomendacaoByIdAsync(id);
            if (recomendacao == null)
            {
                return NotFound();
            }
            return Ok(recomendacao);
        }

        // POST: api/recomendacoes
        [HttpPost]
        public async Task<ActionResult<RecomendacaoLook>> PostRecomendacao(RecomendacaoLook recomendacao)
        {
            var createdRecomendacao = await _recomendacaoLookService.CreateRecomendacaoAsync(recomendacao);
            return CreatedAtAction(nameof(GetRecomendacao), new { id = createdRecomendacao.Id }, createdRecomendacao);
        }

        // PUT: api/recomendacoes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecomendacao(int id, RecomendacaoLook recomendacao)
        {
            if (id != recomendacao.Id)
            {
                return BadRequest();
            }
            await _recomendacaoLookService.UpdateRecomendacaoAsync(recomendacao);
            return NoContent();
        }

        // DELETE: api/recomendacoes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecomendacao(int id)
        {
            var exists = await _recomendacaoLookService.DeleteRecomendacaoAsync(id);
            if (!exists)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
