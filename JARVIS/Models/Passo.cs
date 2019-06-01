using System.Collections.Generic;

namespace JARVIS.Models
{
    public class Passo
    {
        public int idPasso { get; set; }
        public int idReceita { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
    }
}