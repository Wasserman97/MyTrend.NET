using Microsoft.AspNetCore.Mvc;
using MyTrendApp.Models;
using MyTrendApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoresController : ControllerBase
    {
        private readonly CorService _corService;

        public CoresController(CorService corService)
        {
            _corService = corService;
        }

        // GET: api/cores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cor>>> GetCores()
        {
            var cores = await _corService.GetAllCoresAsync();
            return Ok(cores);
        }

        // GET: api/cores/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cor>> GetCor(int id)
        {
            var cor = await _corService.GetCorByIdAsync(id);
            if (cor == null)
            {
                return NotFound();
            }
            return Ok(cor);
        }

        // POST: api/cores
        [HttpPost]
        public async Task<ActionResult<Cor>> PostCor(Cor cor)
        {
            var createdCor = await _corService.CreateCorAsync(cor);
            return CreatedAtAction(nameof(GetCor), new { id = createdCor.Id }, createdCor);
        }

        // PUT: api/cores/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCor(int id, Cor cor)
        {
            if (id != cor.Id)
            {
                return BadRequest();
            }
            await _corService.UpdateCorAsync(cor);
            return NoContent();
        }

        // DELETE: api/cores/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCor(int id)
        {
            var exists = await _corService.DeleteCorAsync(id);
            if (!exists)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
