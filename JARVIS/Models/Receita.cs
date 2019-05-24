using System.Collections.Generic;

namespace JARVIS.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public virtual List<Alimento> Ingredientes { get; set; }
        public int Duracao { get; set; }
        public int Dificuldade { get; set; }
        public virtual List<Passo> Passos { get; set; }
        public float Classificacao { get; set; }
    
    }
}