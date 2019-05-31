using System.Collections.Generic;

namespace JARVIS.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Receita
    {
        public Receita(int id, string nome, string descricao, int duracao, float classificacao, string dificuldade)
        {
            idReceita = id;
            Nome = nome;
            Descricao = descricao;
            Duracao = duracao;
            Classificacao = classificacao;
            Dificuldade = dificuldade;
        }

        public Receita() { }

        public int idReceita { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public virtual List<Alimento> Ingredientes { get; set; }
        public int Duracao { get; set; }
        public string Dificuldade { get; set; }
        public virtual List<Passo> Passos { get; set; }
        public float Classificacao { get; set; }
    }
}
