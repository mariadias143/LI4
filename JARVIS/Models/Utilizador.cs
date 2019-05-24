using System;
using System.Collections.Generic;

namespace JARVIS.Models
{
    public class Utilizador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data_nascimento { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public int Admin { get; set; }
        public virtual Historico Hist { get; set; }
        public virtual Despensa Despensa { get; set; }
        public virtual Planeamento Plano_semanal { get; set; }
        public virtual ListaCompras Lista_compras { get; set; }
        public virtual List<Alimento> Alergeneos { get; set; }
        public virtual List<Alimento> Preferencias { get; set; }


        public class UserContext
        {

        }
    }
}
