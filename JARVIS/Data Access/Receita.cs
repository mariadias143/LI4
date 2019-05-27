using System;
namespace JARVIS.DataAccess
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Receita
    {
        public Receita(int id, String nome, String descricao, TimeSpan duracao)
        {
            idReceita = id;
            Nome = nome;
            Descricao = descricao;
            Duracao = duracao;
        }

        public Receita() { }

        public int idReceita { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public TimeSpan Duracao { get; set; }
    }
}
