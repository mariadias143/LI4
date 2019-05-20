using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LI4.Models
{
    public class Utilizador
    {
        private int id;
        private string nome;
        private DateTime data_nascimento;
        private int username;
        private string password;
        private string email;
        private string foto; // ?
        private int admin;

        public Utilizador(int id, string nome, DateTime data_nascimento, int username, string password, string email, string foto, int admin)
        {
            this.id = id;
            this.nome = nome;
            this.data_nascimento = data_nascimento;
            this.username = username;
            this.password = password;
            this.email = email;
            this.foto = foto;
            this.admin = admin;
        }

        public int GetUsername()
        {
            return username;
        }

        public void SetUsername(int value)
        {
            username = value;
        }

        public string GetPassword()
        {
            return password;
        }

        public void SetPassword(string value)
        {
            password = value;
        }

        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string value)
        {
            email = value;
        }

        public string GetFoto()
        {
            return foto;
        }

        public void SetFoto(string value)
        {
            foto = value;
        }

        public int GetAdmin()
        {
            return admin;
        }

        public void SetAdmin(int value)
        {
            admin = value;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string value)
        {
            nome = value;
        }

        public override bool Equals(object obj)
        {
            return obj is Utilizador utilizador &&
                   id == utilizador.id &&
                   nome == utilizador.nome &&
                   data_nascimento == utilizador.data_nascimento &&
                   username == utilizador.username &&
                   password == utilizador.password &&
                   email == utilizador.email &&
                   foto == utilizador.foto &&
                   admin == utilizador.admin;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
