using System.Collections.Generic;

namespace JARVIS.Models
{
    public class Passo
    {
        public int idPasso { get; set; }
        public int idReceita { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }

        public Passo()
        {
            idPasso = -1;
            idReceita = -1;
            Descricao = null;
            Ordem = -1;
        }

        public Passo(int idPasso, int idr, string desc, int o)
        {
            this.idPasso = idPasso;
            idReceita = idr;
            Descricao = desc;
            Ordem = o;
        }
    }
}