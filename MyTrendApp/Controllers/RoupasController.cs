using Microsoft.AspNetCore.Mvc;
using MyTrendApp.Models;
using MyTrendApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoupasController : ControllerBase
    {
        private readonly RoupaService _roupaService;

        public RoupasController(RoupaService roupaService)
        {
            _roupaService = roupaService;
        }

        // GET: api/roupas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roupa>>> GetRoupas()
        {
            var roupas = await _roupaService.GetAllRoupasAsync();
            return Ok(roupas);
        }

        // GET: api/roupas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Roupa>> GetRoupa(int id)
        {
            var roupa = await _roupaService.GetRoupaByIdAsync(id);
            if (roupa == null)
            {
                return NotFound();
            }
            return Ok(roupa);
        }

        // POST: api/roupas
        [HttpPost]
        public async Task<ActionResult<Roupa>> PostRoupa(Roupa roupa)
        {
            var createdRoupa = await _roupaService.CreateRoupaAsync(roupa);
            return CreatedAtAction(nameof(GetRoupa), new { id = createdRoupa.Id }, createdRoupa);
        }

        // PUT: api/roupas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoupa(int id, Roupa roupa)
        {
            if (id != roupa.Id)
            {
                return BadRequest();
            }
            await _roupaService.UpdateRoupaAsync(roupa);
            return NoContent();
        }

        // DELETE: api/roupas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoupa(int id)
        {
            var exists = await _roupaService.DeleteRoupaAsync(id);
            if (!exists)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
