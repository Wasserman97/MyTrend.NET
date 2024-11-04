using Microsoft.AspNetCore.Mvc;
using MyTrendApp.Models;
using MyTrendApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaProdutoService _categoriaProdutoService;

        public CategoriasController(CategoriaProdutoService categoriaProdutoService)
        {
            _categoriaProdutoService = categoriaProdutoService;
        }

        // GET: api/categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaProduto>>> GetCategorias()
        {
            var categorias = await _categoriaProdutoService.GetAllCategoriasAsync();
            return Ok(categorias);
        }

        // GET: api/categorias/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaProduto>> GetCategoria(int id)
        {
            var categoria = await _categoriaProdutoService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        // POST: api/categorias
        [HttpPost]
        public async Task<ActionResult<CategoriaProduto>> PostCategoria(CategoriaProduto categoria)
        {
            var createdCategoria = await _categoriaProdutoService.CreateCategoriaAsync(categoria);
            return CreatedAtAction(nameof(GetCategoria), new { id = createdCategoria.Id }, createdCategoria);
        }

        // PUT: api/categorias/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, CategoriaProduto categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }
            await _categoriaProdutoService.UpdateCategoriaAsync(categoria);
            return NoContent();
        }

        // DELETE: api/categorias/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var exists = await _categoriaProdutoService.DeleteCategoriaAsync(id);
            if (!exists)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

