using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace JARVIS.DataAccess
{
    public class UtilizadorDAO : IDAO<Utilizador>
    {
        private IConnection _connection;

        public UtilizadorDAO(IConnection connection)
        {
            _connection = connection;
        }

        public Utilizador FindById(string key)
        {
            throw new NotImplementedException();
        }

        public Utilizador Insert(Utilizador obj)
        {
            //SqCommand command ...
            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Utilizador values (@idUtilizador,@Nome,@DataNascimento,@Username,@Password,@Email,@Foto,@Admin)";

                command.Parameters.Add("@idUtilizador", SqlDbType.Int).Value = obj.idUtilizador;
                command.Parameters.Add("@Nome", SqlDbType.Text).Value = obj.Nome;
                command.Parameters.Add("@DataNascimento", SqlDbType.Date).Value = obj.DataNascimento;
                command.Parameters.Add("@Username", SqlDbType.Text).Value = obj.Username;
                command.Parameters.Add("@Password", SqlDbType.Text).Value = obj.Password;
                command.Parameters.Add("@Email", SqlDbType.Text).Value = obj.Email;
                command.Parameters.Add("@Foto", SqlDbType.Text).Value = obj.Foto;
                command.Parameters.Add("@Admin", SqlDbType.TinyInt).Value = obj.Admin;

                command.ExecuteNonQuery();
                // obj.Id = command.ExecuteScalar().ToString(); -> devolve o valor da primeira linha e primeira coluna da tabela em questão
                //
            }
            return obj;
        }


        public Collection<Utilizador> ListAll()
        {
            Collection<Utilizador> utilizadores = new Collection<Utilizador>();
            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT idUtilizador, Nome, DataNascimento, Username, Password, Email, Foto, Admin";

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable tab = new DataTable();
                    adapter.Fill(tab);

                    foreach (DataRow row in tab.Rows)
                    {
                        Utilizador a = new Utilizador
                        {
                            idUtilizador = int.Parse(row["idUtilizador"].ToString()),
                            Nome = row["Nome"].ToString(),
                            DataNascimento = DateTime.Parse(row["DataNascimento"].ToString()),
                            Username = row["Username"].ToString(),
                            Password = row["Password"].ToString(),
                            Email = row["Email"].ToString(),
                            Foto = row["Foto"].ToString(),
                            Admin = Boolean.Parse(row["Admin"].ToString())
                        };
                        utilizadores.Add(a);
                    }
                }
                return utilizadores;
            }
        }

        public bool remove(Utilizador obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Utilizador obj)
        {
            bool updated = false;
            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Utilizador Set Nome==Nome WHERE idUtilizador==idUtilizador";

                command.Parameters.Add("@Nome", SqlDbType.Text).Value = obj.Nome;
                command.Parameters.Add("@idUtilizador", SqlDbType.Int).Value = obj.idUtilizador;

                if (command.ExecuteNonQuery() > 0)
                {
                    updated = true;
                }
            }
            return updated;
        }
    }
}
