using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            SelectedFoods = new List<string>();
            AvailableFoods = new List<SelectListItem>();
        }

        public Receita()
        {
            SelectedFoods = new List<string>();
            AvailableFoods = new List<SelectListItem>();
        }

        public int idReceita { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public virtual List<Alimento> Ingredientes { get; set; }
        public int Duracao { get; set; }
        public string Dificuldade { get; set; }
        public virtual List<Passo> Passos { get; set; }
        public float Classificacao { get; set; }
        public IList<string> SelectedFoods { get; set; }
        public IList<SelectListItem> AvailableFoods { get; set; }

        public void executaReceita(List<Alimento> l) { }
    }
}
