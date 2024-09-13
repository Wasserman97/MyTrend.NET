using Microsoft.AspNetCore.Mvc;
using MyTrendApp.Models;
using MyTrendApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidosController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // GET: api/pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            var pedidos = await _pedidoService.GetAllPedidosAsync();
            return Ok(pedidos);
        }

        // GET: api/pedidos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _pedidoService.GetPedidoByIdAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        // POST: api/pedidos
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            var createdPedido = await _pedidoService.CreatePedidoAsync(pedido);
            return CreatedAtAction(nameof(GetPedido), new { id = createdPedido.Id }, createdPedido);
        }

        // PUT: api/pedidos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }
            await _pedidoService.UpdatePedidoAsync(pedido);
            return NoContent();
        }

        // DELETE: api/pedidos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var exists = await _pedidoService.DeletePedidoAsync(id);
            if (!exists)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
