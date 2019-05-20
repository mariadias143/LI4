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
        private List<Alimento> ingredientes {get; set;}
        private int duracao {get; set;} // em minutos
        private List<Passo> passos {get; set;}
        private List<Avaliacao> avaliacoes {get; set;}
    
    }
}