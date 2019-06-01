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

        public Avaliacao FindById(string key)
        {
            throw new NotImplementedException();
        }

        public Avaliacao Insert(Avaliacao obj)
        {
            //SqCommand command ...
            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Avaliacao values (@idAvaliacao,@Classificacao,@idReceita,@idUtilizador)";

                command.Parameters.Add("@idAvaliacao", SqlDbType.Int).Value = obj.idAvaliacao;
                command.Parameters.Add("@Classificacao", SqlDbType.Int).Value = obj.Classificacao;
                command.Parameters.Add("@idReceita", SqlDbType.Int).Value = obj.idReceita;
                command.Parameters.Add("@idUtilizador", SqlDbType.Int).Value = obj.idUtilizador;

                command.ExecuteNonQuery();
                // obj.Id = command.ExecuteScalar().ToString(); -> devolve o valor da primeira linha e primeira coluna da tabela em questão
                //
            }
            return obj;
        }

        public Collection<Avaliacao> ListAll()
        {
            Collection<Avaliacao> avaliacoes = new Collection<Avaliacao>();
            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT idAvaliacao, Classificacao, idReceita, idUtilizador";

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable tab = new DataTable();
                    adapter.Fill(tab);

                    foreach (DataRow row in tab.Rows)
                    {
                        Avaliacao a = new Avaliacao
                        {
                            idAvaliacao = int.Parse(row["idAvaliacao"].ToString()),
                            Classificacao = int.Parse(row["Classificacao"].ToString()),
                            idReceita = int.Parse(row["idReceita"].ToString()),
                            idUtilizador = int.Parse(row["idUtilizador"].ToString())
                        };
                        avaliacoes.Add(a);
                    }
                }
                return avaliacoes;
            }
        }

        public bool remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool Update(string key, Avaliacao obj)
        {
            bool updated = false;
            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Avaliacao Set Classificacao==Classificacao WHERE idAvaliacao==idAvaliacao";

                command.Parameters.Add("@Classificacao", SqlDbType.Int).Value = obj.Classificacao;
                command.Parameters.Add("@idAvaliacao", SqlDbType.Int).Value = obj.idAvaliacao;

                if (command.ExecuteNonQuery() > 0)
                {
                    updated = true;
                }
            }
            return updated;
        }


    }
}
