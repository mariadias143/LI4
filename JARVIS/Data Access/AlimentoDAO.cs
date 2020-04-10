using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using JARVIS.Models;

namespace JARVIS.DataAccess
{
    public class AlimentoDAO : IDAO<Alimento>
    {
        private IConnection _connection;

        public AlimentoDAO(IConnection connection)
        {
            _connection = connection;
        }

        public Alimento FindById(int key)
        {
            Alimento a = new Alimento();
            using (SqlConnection con = _connection.Fetch())
            {
                string query = "SELECT * FROM Alimento where idAlimento=@idAlimento";
                var dt = new DataTable();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@idAlimento", key);
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        a.idAlimento = int.Parse(row["idAlimento"].ToString());
                        a.Nome = row["Nome"].ToString();
                        a.ValorNutricional = double.Parse(row["ValorNutricional"].ToString());
                        a.Validade = DateTime.Parse(row["Validade"].ToString());
                    }
                }
            }
            return a;
        }

        public Alimento FindByName(string key)
        {
            Alimento a = new Alimento();
            using (SqlConnection con = _connection.Fetch())
            {
                string query = "SELECT * FROM Alimento where Nome=@nome";
                var dt = new DataTable();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@nome", key);
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        a.idAlimento = int.Parse(row["idAlimento"].ToString());
                        a.Nome = row["Nome"].ToString();
                        a.ValorNutricional = double.Parse(row["ValorNutricional"].ToString());
                        a.Validade = DateTime.Parse(row["Validade"].ToString());
                    }
                }

                query = "SELECT * FROM Alimento_Alternativo where idAlimento=@id";
                dt = new DataTable();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@id", a.idAlimento);
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        a.alternativo = int.Parse(row["idAlimentoAlt"].ToString());
                    }
                }

            }
            return a;
        }

        public Alimento Insert(Alimento obj)
        {
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "INSERT INTO dbo.Alimento(Nome,ValorNutricional,Validade) values (@Nome,@ValorNutricional,@Validade)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = obj.Nome;
                    command.Parameters.Add("@ValorNutricional", SqlDbType.Decimal).Value = obj.ValorNutricional;
                    command.Parameters.Add("@Validade", SqlDbType.Date).Value = obj.Validade;

                    command.ExecuteNonQuery();

                }
            }
            return obj;
        }

        public Collection<Alimento> ListAll()
        {
            Collection<Alimento> alimentos = new Collection<Alimento>();
            using (SqlConnection con = _connection.Fetch())
            {
                string queryString = "SELECT * FROM Alimento";

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(queryString, con);
                    DataSet tab = new DataSet();
                    adapter.Fill(tab);

                    foreach (DataTable table in tab.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            Alimento a = new Alimento
                            {
                                idAlimento = int.Parse(row["idAlimento"].ToString()),
                                Nome = row["Nome"].ToString(),
                                ValorNutricional = double.Parse(row["ValorNutricional"].ToString()),
                                Validade = DateTime.Parse(row["Validade"].ToString())
                            };

                            queryString = "SELECT * FROM Alimento_Alternativo where idAlimento=@id";
                            DataTable dt = new DataTable();
                            using (SqlCommand command = new SqlCommand(queryString, con))
                            {
                                command.Parameters.AddWithValue("@id", a.idAlimento);
                                SqlDataReader reader = command.ExecuteReader();
                                dt.Load(reader);
                                reader.Close();

                                foreach (DataRow row2 in dt.Rows)
                                {
                                    a.alternativo = int.Parse(row2["idAlimentoAlt"].ToString());
                                }
                            }

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
                String query = "DELETE FROM dbo.Alimento where idAlimento=@idAlimento";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@idAlimento", key);
                    if (command.ExecuteNonQuery() > 0)
                    {
                        removed = true;
                    }
                }
            }
            return removed;
        }

        public bool Update(string key, Alimento obj)
        {
            bool updated = false;
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "UPDATE dbo.Alimento SET Nome=@Nome, ValorNutricional=@ValorNutricional, Validade=@Validade WHERE idAlimento=@idAlimento";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Nome", obj.Nome);
                    command.Parameters.AddWithValue("@ValorNutricional", obj.ValorNutricional);
                    command.Parameters.AddWithValue("@Validade", obj.Validade);
                    command.Parameters.AddWithValue("@idAlimento", key);

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

