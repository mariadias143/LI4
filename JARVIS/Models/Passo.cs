using System.Collections.Generic;

namespace JARVIS.Models
{
    public class Passo
    {
        public int Id {get; set;}
        public virtual List<string> Instrucoes {get; set;}
    }
}