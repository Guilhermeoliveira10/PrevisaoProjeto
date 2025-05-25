using Microsoft.ML;
using PrevisaoProjeto.Models;
using PrevisaoProjeto.DTOs;
using System.IO;
using System;

namespace PrevisaoProjeto.Services
{
    public class PrevisorService
    {
        private readonly MLContext _mlContext;
        private PredictionEngine<Entrada, Saida> _engine;

        public PrevisorService()
        {
            try
            {
                _mlContext = new MLContext();
                var dataPath = Path.Combine("Data", "dados.csv");

                if (!File.Exists(dataPath))
                    throw new FileNotFoundException("Arquivo dados.csv não encontrado em: " + dataPath);

                var data = _mlContext.Data.LoadFromTextFile<Entrada>(
                    dataPath, hasHeader: true, separatorChar: ',');

                var split = _mlContext.Data.TrainTestSplit(data, testFraction: 0.3);

                var pipeline = _mlContext.Transforms.Conversion
                    .ConvertType("Comprou", outputKind: Microsoft.ML.Data.DataKind.Boolean)
                    .Append(_mlContext.Transforms.Concatenate("Features", "Idade", "Salario"))
                    .Append(_mlContext.BinaryClassification.Trainers.FastTree(labelColumnName: "Comprou"));

                var model = pipeline.Fit(split.TrainSet);

                var predictions = model.Transform(split.TestSet);
                var metrics = _mlContext.BinaryClassification.Evaluate(predictions, labelColumnName: "Comprou");
                Console.WriteLine($"📊 Acurácia: {metrics.Accuracy:P2}");

                _engine = _mlContext.Model.CreatePredictionEngine<Entrada, Saida>(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inicializar modelo de previsão: " + ex.Message);
                throw;
            }
        }

        public PrevisaoResponseDto Prever(PrevisaoRequestDto dados)
        {
            var input = new Entrada
            {
                Idade = dados.Idade,
                Salario = dados.Salario
            };

            var resultado = _engine.Predict(input);

            return new PrevisaoResponseDto
            {
                Predicao = resultado.Predicao,
                Probabilidade = resultado.Probabilidade,
                Score = resultado.Score
            };
        }
    }

    public class Saida
    {
        public bool Predicao { get; set; }
        public float Probabilidade { get; set; }
        public float Score { get; set; }
    }
}
