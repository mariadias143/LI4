using System;
namespace JARVIS.DataAccess
{
    public class Alimento
    {
        public Alimento(int id, string nome, double valorNutricional, DateTime validade)
        {
            idAlimento = id;
            Nome = nome;
            ValorNutricional = valorNutricional;
            Validade = validade;
        }

        public Alimento() { }

        public int idAlimento { get; set; }
        public String Nome { get; set; }
        public double ValorNutricional { get; set; }
        public DateTime Validade { get; set; }

    }
}
