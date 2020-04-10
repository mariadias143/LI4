using System;
using System.Collections.Generic;


namespace JARVIS.Models
{
    public class Alimento_Receita
    {
        public int idReceita { get; set; }
        public virtual Alimento alimento { get; set; }

    }

}