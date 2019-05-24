using System;
using System.Collections.Generic;

namespace JARVIS.Models
{
    public class Alimento
    {
        public int Id { get; set; }
        public float ValorNutricional { get; set; }
        public DateTime Validade { get; set; }
        public string Nome { get; set; }
        public virtual List<Alimento> Alternativos { get; set; }
    }
}
