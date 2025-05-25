using Microsoft.ML.Data;

namespace PrevisaoProjeto.Models
{
    public class Entrada
    {
        [LoadColumn(0)]
        public float Idade { get; set; }

        [LoadColumn(1)]
        public float Salario { get; set; }

        [LoadColumn(2), ColumnName("Comprou")]
        public bool Comprou { get; set; }
    }
}
