using System;
namespace JARVIS.DataAccess
{
    public class Utilizador
    {
        public Utilizador(int id, string nome, DateTime data, string username, string pass, string email, string foto, bool admin)
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
        public String Foto { get; set; }
        public bool Admin { get; set; }

    }
}
