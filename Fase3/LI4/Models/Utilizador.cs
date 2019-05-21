using System;

namespace LI4.Models
{
    public class Utilizador
    {
        public int id;
        public string nome;
        public DateTime data_nascimento;
        public int username;
        public string password;
        public string email;
        public string foto;
        public int admin;

        public class UserContext
        {

        }
    }
}
