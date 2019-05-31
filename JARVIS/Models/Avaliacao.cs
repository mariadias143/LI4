namespace JARVIS.Models
{
    public class Avaliacao
    {
        public Avaliacao(int id, float classificacao, int idR, int idUt)
        {
            idAvaliacao = id;
            Classificacao = classificacao;
            idReceita = idR;
            idUtilizador = idUt;
        }

        public Avaliacao() { }

        public int idAvaliacao { get; set; }
        public float Classificacao { get; set; }
        public int idReceita { get; set; }
        public int idUtilizador { get; set; }
    }
}