using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using JARVIS.Models;

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
            Utilizador u = new Utilizador();
            using (SqlConnection con = _connection.Fetch())
            {
                string query = "SELECT * FROM Utilizador where idUtilizador=@idUtilizador";
                var dt = new DataTable();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@idUtilizador", key);
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        u.idUtilizador = int.Parse(row["idUtilizador"].ToString());
                        u.Nome = row["Nome"].ToString();
                        u.DataNascimento = DateTime.Parse(row["DataNascimento"].ToString());
                        u.Username = row["Username"].ToString();
                        u.Password = row["Password"].ToString();
                        u.Email = row["Email"].ToString();
                        u.Foto = row["Foto"].ToString();
                        u.Admin = int.Parse(row["Admin"].ToString());
                    }
                }
            }
            return u;
        }


        public Utilizador Insert(Utilizador obj)
        {
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "INSERT INTO dbo.Utilizador(Nome,DataNascimento,Username,Password,Email,Foto,Admin) values (@Nome,@DataNascimento,@Username,@Password,@Email,@Foto,@Admin)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = obj.Nome ?? (object)DBNull.Value;
                    command.Parameters.Add("@DataNascimento", SqlDbType.Date).Value = obj.DataNascimento;
                    command.Parameters.Add("@Username", SqlDbType.VarChar).Value = obj.Username ?? (object)DBNull.Value;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = obj.Password ?? (object)DBNull.Value;
                    command.Parameters.Add("@Email", SqlDbType.VarChar).Value = obj.Email ?? (object)DBNull.Value;
                    command.Parameters.Add("@Foto", SqlDbType.VarChar).Value = obj.Foto ?? (object)DBNull.Value;
                    command.Parameters.AddWithValue("@Admin", 0);

                    command.ExecuteNonQuery();

                }
            }
            return obj;
        }


        public Collection<Utilizador> ListAll()
        {
            Collection<Utilizador> alimentos = new Collection<Utilizador>();
            using (SqlConnection con = _connection.Fetch())
            {
                string queryString = "SELECT * FROM Utilizador";

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(queryString, con);
                    DataSet tab = new DataSet();
                    adapter.Fill(tab);

                    foreach (DataTable table in tab.Tables)
                    {
                        foreach (DataRow row in table.Rows)
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
                                Admin = int.Parse(row["Admin"].ToString())
                            };
                            alimentos.Add(a);
                        }
                    }
                }
                return alimentos;
            }
        }

        public bool remove(string key)
        {
            bool removed = false;
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "DELETE FROM dbo.Utilizador where idUtilizador=@idUtilizador";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@idUtilizador", key);
                    if (command.ExecuteNonQuery() > 0)
                    {
                        removed = true;
                    }
                }
            }
            return removed;
        }

        public bool Update(string key, Utilizador obj)
        {
            bool updated = false;
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "UPDATE dbo.Utilizador SET Nome=@Nome, DataNascimento=@DataNascimento, Username=@Username, Password=@Password, Email=@Email, Foto=@Foto WHERE idUtilizador=@idUtilizador";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Nome", obj.Nome);
                    command.Parameters.AddWithValue("@DataNascimento", obj.DataNascimento);
                    command.Parameters.AddWithValue("@Username", obj.Username);
                    command.Parameters.AddWithValue("@Password", obj.Password);
                    command.Parameters.AddWithValue("@Email", obj.Email);
                    command.Parameters.AddWithValue("@Foto", obj.Foto);
                    command.Parameters.AddWithValue("@idUtilizador", key);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        updated = true;
                    }
                }
            }
            return updated;
        }
    }
}
