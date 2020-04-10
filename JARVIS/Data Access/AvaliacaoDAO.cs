using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using JARVIS.Models;

namespace JARVIS.DataAccess
{
    public class AvaliacaoDAO : IDAO<Avaliacao>
    {
        private IConnection _connection;

        public AvaliacaoDAO(IConnection connection)
        {
            _connection = connection;
        }

        public Avaliacao FindById(int key)
        {
            Avaliacao a = new Avaliacao();
            using (SqlConnection con = _connection.Fetch())
            {

                string query = "SELECT * FROM Avaliacao where idAvaliacao=@idAvaliacao";
                var dt = new DataTable();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@idAvaliacao", key);
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        a.idAvaliacao = int.Parse(row["idAvaliacao"].ToString());
                        a.Classificacao = int.Parse(row["Classificacao"].ToString());
                        a.idReceita = int.Parse(row["idReceita"].ToString());
                        a.idUtilizador = int.Parse(row["idUtilizador"].ToString());
                    }
                }
            }
            return a;
        }

        public Avaliacao FindByName(string key)
        {
            throw new NotImplementedException();
        }

        public Avaliacao Insert(Avaliacao obj)
        {
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "INSERT INTO dbo.Avaliacao(Classificacao,IdReceita,IdUtilizador) values (@Classificacao,@IdReceita,@IdUtilizador)";

                using (SqlCommand command = new SqlCommand(query,con))
                {

                    command.Parameters.Add("@Classificacao", SqlDbType.Int).Value = obj.Classificacao;
                    command.Parameters.Add("@idReceita", SqlDbType.Int).Value = obj.idReceita;
                    command.Parameters.Add("@idUtilizador", SqlDbType.Int).Value = obj.idUtilizador;

                    command.ExecuteNonQuery();
                }
            }
            return obj;
        }

        public Collection<Avaliacao> ListAll()
        {
            Collection<Avaliacao> avaliacoes = new Collection<Avaliacao>();
            using (SqlConnection con = _connection.Fetch())
            {
                string queryString = "SELECT * FROM Avaliacao";

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(queryString, con);
                    DataSet tab = new DataSet();
                    adapter.Fill(tab);

                    foreach (DataTable table in tab.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            Avaliacao a = new Avaliacao
                            {
                                Classificacao = int.Parse(row["Classificacao"].ToString()),
                                idReceita = int.Parse(row["idReceita"].ToString()),
                                idUtilizador = int.Parse(row["idUtilizador"].ToString())
                            };
                            avaliacoes.Add(a);
                        }
                    }
                }
                return avaliacoes;
            }
        }

        public bool remove(string key)
        {
            bool removed = false;
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "DELETE FROM dbo.Avaliacao where idAvaliacao=@idAvaliacao";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@idAvaliacao", key);
                    if (command.ExecuteNonQuery() > 0)
                    {
                        removed = true;
                    }
                }
            }
            return removed;
        }

        public bool Update(string key, Avaliacao obj)
        {
            bool updated = false;
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "UPDATE dbo.Utilizador SET Classificacao=@Classificacao, idReceita=@idReceita, idUtilizador=@idUtilizador WHERE idAvaliacao=@idAvaliacao";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Classificacao", obj.Classificacao);
                    command.Parameters.AddWithValue("@idReceita", obj.idReceita);
                    command.Parameters.AddWithValue("@idUtilizador", obj.idUtilizador);
                    command.Parameters.AddWithValue("@idAvaliacao", key);

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
