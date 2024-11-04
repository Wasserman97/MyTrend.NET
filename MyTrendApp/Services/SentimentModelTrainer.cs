
using Microsoft.ML;
using System.IO;

public class SentimentModelTrainer
{
    private static readonly string ModelPath = "MLModels/sentiment_model.zip";

    public static void TrainAndSaveModel()
    {
        var mlContext = new MLContext();

        var trainingData = mlContext.Data.LoadFromEnumerable(new[]
        {
            new SentimentData { Text = "I love this product!", Label = true },
            new SentimentData { Text = "This is bad", Label = false }
        });

        var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.Text))
            .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression("Label", "Features"));

        var model = pipeline.Fit(trainingData);
        mlContext.Model.Save(model, trainingData.Schema, ModelPath);
    }
}
