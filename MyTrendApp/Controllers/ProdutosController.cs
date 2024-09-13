using Microsoft.AspNetCore.Mvc;
using MyTrendApp.Models;
using MyTrendApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET: api/produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await _produtoService.GetAllProdutosAsync();
            return Ok(produtos);

        }

        // GET: api/produtos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        // POST: api/produtos
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            var createdProduto = await _produtoService.CreateProdutoAsync(produto);
            return CreatedAtAction(nameof(GetProduto), new { id = createdProduto.Id }, createdProduto);
        }

        // PUT: api/produtos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }
            await _produtoService.UpdateProdutoAsync(produto);
            return NoContent();
        }

        // DELETE: api/produtos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var exists = await _produtoService.DeleteProdutoAsync(id);
            if (!exists)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

