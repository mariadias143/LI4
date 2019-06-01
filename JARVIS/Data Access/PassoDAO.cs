using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using JARVIS.Models;

namespace JARVIS.DataAccess
{
    public class PassoDAO : IDAO<Passo>
    {
        private IConnection _connection;

        public PassoDAO(IConnection connection)
        {
            _connection = connection;
        }

        public Passo FindById(string key)
        {
            Passo p = new Passo();
            using (SqlConnection con = _connection.Fetch())
            {
                string query = "SELECT * FROM Instrução where idPasso=@idPasso";
                var dt = new DataTable();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@idPasso", key);
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        p.idPasso = int.Parse(row["idPasso"].ToString());
                        p.Descricao = row["Descricao"].ToString();
                        p.Ordem = int.Parse(row["Ordem"].ToString());
                        p.idReceita = int.Parse(row["idReceita"].ToString());
                    }
                }
            }
            return p;
        }

        public Passo Insert(Passo obj)
        {
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "INSERT INTO dbo.Instrução(Descricao,Ordem,idReceita) values (@Descricao,@Ordem,@idReceita)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = obj.Descricao;
                    command.Parameters.Add("@Ordem", SqlDbType.Int).Value = obj.Ordem;
                    command.Parameters.Add("@idReceita", SqlDbType.Int).Value = obj.idReceita;

                    command.ExecuteNonQuery();

                }
            }
            return obj;
        }

        public Collection<Passo> ListAll()
        {
            Collection<Passo> passos = new Collection<Passo>();
            using (SqlConnection con = _connection.Fetch())
            {
                string queryString = "SELECT * FROM Instrução";

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(queryString, con);
                    DataSet tab = new DataSet();
                    adapter.Fill(tab);

                    foreach (DataTable table in tab.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            Passo p = new Passo
                            {
                                idPasso = int.Parse(row["idPasso"].ToString()),
                                Descricao = row["Descricao"].ToString(),
                                Ordem = int.Parse(row["Ordem"].ToString()),
                                idReceita = int.Parse(row["idReceita"].ToString())
                            };
                            passos.Add(p);
                        }
                    }
                }
                return passos;
            }
        }

        public bool remove(string key)
        {
            bool removed = false;
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "DELETE FROM dbo.Instrução where idPasso=@idPasso";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@idPasso", key);
                    if(command.ExecuteNonQuery() > 0)
                    {
                        removed = true;
                    }
                }
            }
            return removed;
        }

        public bool Update(string key, Passo obj)
        {
            bool updated = false;
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "UPDATE dbo.Instrução SET Descricao=@Descricao, Ordem=@Ordem, idReceita=@idReceita WHERE idPasso=@idPasso";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Descricao", obj.Descricao);
                    command.Parameters.AddWithValue("@Ordem", obj.Ordem);
                    command.Parameters.AddWithValue("@idReceita", obj.idReceita);

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
