
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SentimentController : ControllerBase
{
    private readonly SentimentPredictionService _sentimentService;

    public SentimentController(SentimentPredictionService sentimentService)
    {
        _sentimentService = sentimentService;
    }

    [HttpPost("analyze")]
    public IActionResult AnalyzeSentiment([FromBody] string text)
    {
        var result = _sentimentService.PredictSentiment(text);
        return Ok(new
        {
            Prediction = result.Prediction,
            Probability = result.Probability,
            Score = result.Score
        });
    }
}
