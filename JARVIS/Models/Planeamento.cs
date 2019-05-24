using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JARVIS.Models
{
    public class Planeamento
    {
        public virtual Dictionary<int, List<int>> Semana { set; get; } // key é o dia da semana[1 a 7] 
                                                    //value é lista de tamanho 4 dos ids da receita correspondente
    }
}
