using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LI4.Models
{
    public class Receita
    {
        private int id {get; set;}
        private string descricao {get; set;}
        private string nome {get; set;}
        private int idProprietario {get; set;} // é preciso?? vamos por gajos a publicarem receitas?
        private ArrayList<Alimento> ingredientes {get; set;}
        private int duracao {get; set;} // em minutos
        private ArrayList<Passo> passos {get; set;}
        private ArrayList<Avaliacao> avaliacoes {get; set;}
    
    }
}