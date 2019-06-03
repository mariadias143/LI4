using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JARVIS.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Receita
    {
<<<<<<< HEAD
        public Receita()
        {
        }

        public Receita(int idr, string nome, string descricao, int duracao, float classificacao, string dificuldade)
        {
            idReceita = idr;
=======
        public Receita(int id, string nome, string descricao, int duracao, float classificacao, string dificuldade)
        {
            idReceita = id;
>>>>>>> 726f6e1fed68bbf5c36d05b3e60e13b394906930
            Nome = nome;
            Descricao = descricao;
            Duracao = duracao;
            Classificacao = classificacao;
            Dificuldade = dificuldade;
        }

        public int idReceita { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public virtual List<Alimento> Ingredientes { get; set; }
        public int Duracao { get; set; }
        public string Dificuldade { get; set; }
        public virtual List<Passo> Passos { get; set; }
        public float Classificacao { get; set; }
        public List<int> indispensaveis { get; set; } = new List<int>();

        public void executaReceita(List<Alimento> l) { }
    }
}
