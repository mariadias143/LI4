using System;
using System.Collections.Generic;

namespace JARVIS.Models
{
    public class Utilizador
    {
        public Utilizador(int id, string nome, DateTime data, string username, string pass, string email, byte[] foto, int admin)
        {
            idUtilizador = id;
            Nome = nome;
            DataNascimento = data;
            Username = username;
            Password = pass;
            Email = email;
            Foto = foto;
            Admin = admin;
        }

        public Utilizador() { }

        public int idUtilizador { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public byte[] Foto { get; set; }
        public int Admin { get; set; }
        public virtual Historico Hist { get; set; }
        public virtual Despensa Despensa { get; set; }
        public virtual Planeamento Plano_semanal { get; set; }
        public virtual ListaCompras Lista_compras { get; set; }
        public virtual List<Alimento> Alergeneos { get; set; }
        public virtual List<Alimento> Preferencias { get; set; }

    }
}