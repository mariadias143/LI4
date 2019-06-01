namespace JARVIS.Models
{
    public class Avaliacao
    {
        public Avaliacao(int id, int classificacao, int idR, int idUt)
        {
            idAvaliacao = id;
            Classificacao = classificacao;
            idReceita = idR;
            idUtilizador = idUt;
        }

        public Avaliacao() { }

        public int idAvaliacao { get; set; }
        public int Classificacao { get; set; }
        public int idReceita { get; set; }
        public int idUtilizador { get; set; }
    }
}