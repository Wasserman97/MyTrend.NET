
using Microsoft.ML;
using System;

public class SentimentPredictionService
{
    private readonly MLContext _mlContext;
    private readonly ITransformer _model;

    public SentimentPredictionService()
    {
        _mlContext = new MLContext();
        _model = _mlContext.Model.Load("MLModels/sentiment_model.zip", out var _);
    }

    public SentimentPrediction PredictSentiment(string text)
    {
        var predictionEngine = _mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(_model);
        var prediction = predictionEngine.Predict(new SentimentData { Text = text });
        return prediction;
    }
}
