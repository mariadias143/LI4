using System;
namespace JARVIS.DataAccess
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Receita
    {
        public Receita(int id, String nome, String descricao, int duracao, float classificacao, string dificuldade)
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
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public int Duracao { get; set; }
        public String Dificuldade { get; set; }
        public float Classificacao { get; set; }
    }
}
