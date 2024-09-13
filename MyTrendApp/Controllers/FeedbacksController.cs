using Microsoft.AspNetCore.Mvc;
using MyTrendApp.Models;
using MyTrendApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbacksController : ControllerBase
    {
        private readonly FeedbackUsuarioService _feedbackUsuarioService;

        public FeedbacksController(FeedbackUsuarioService feedbackUsuarioService)
        {
            _feedbackUsuarioService = feedbackUsuarioService;
        }

        // GET: api/feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackUsuario>>> GetFeedbacks()
        {
            var feedbacks = await _feedbackUsuarioService.GetAllFeedbacksAsync();
            return Ok(feedbacks);
        }

        // GET: api/feedbacks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackUsuario>> GetFeedback(int id)
        {
            var feedback = await _feedbackUsuarioService.GetFeedbackByIdAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        // POST: api/feedbacks
        [HttpPost]
        public async Task<ActionResult<FeedbackUsuario>> PostFeedback(FeedbackUsuario feedback)
        {
            var createdFeedback = await _feedbackUsuarioService.CreateFeedbackAsync(feedback);
            return CreatedAtAction(nameof(GetFeedback), new { id = createdFeedback.Id }, createdFeedback);
        }

        // PUT: api/feedbacks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(int id, FeedbackUsuario feedback)
        {
            if (id != feedback.Id)
            {
                return BadRequest();
            }
            await _feedbackUsuarioService.UpdateFeedbackAsync(feedback);
            return NoContent();
        }

        // DELETE: api/feedbacks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var exists = await _feedbackUsuarioService.DeleteFeedbackAsync(id);
            if (!exists)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
