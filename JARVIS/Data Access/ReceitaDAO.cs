using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using JARVIS.Models;

namespace JARVIS.DataAccess
{
    public class ReceitaDAO : IDAO<Receita>
    {
        private IConnection _connection;

        public ReceitaDAO(IConnection connection)
        {
            _connection = connection;
        }

        public Receita FindById(string key)
        {

            throw new NotImplementedException();
        }

        public Receita Insert(Receita obj)
        {
            //SqCommand command ...
            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Receita values (@idReceita,@Nome,@Descricao,@Duracao)";

                command.Parameters.Add("@idReceita", SqlDbType.Int).Value = obj.idReceita;
                command.Parameters.Add("@Nome", SqlDbType.Text).Value = obj.Nome;
                command.Parameters.Add("@Descricao", SqlDbType.Text).Value = obj.Descricao;
                command.Parameters.Add("@Duracao", SqlDbType.Time).Value = obj.Duracao;

                command.ExecuteNonQuery();
                // obj.Id = command.ExecuteScalar().ToString(); -> devolve o valor da primeira linha e primeira coluna da tabela em questão
                //
            }
            return obj;
        }

        public Collection<Receita> ListAll()
        {
            Collection<Receita> receitas = new Collection<Receita>();
            using (SqlConnection con = _connection.Fetch())
            {
                string queryString = "SELECT * FROM Receita";

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(queryString, con);
                    DataSet tab = new DataSet();
                    adapter.Fill(tab);

                    foreach (DataTable table in tab.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            Receita a = new Receita
                            {
                                idReceita = int.Parse(row["idReceita"].ToString()),
                                Nome = row["Nome"].ToString(),
                                Descricao = row["Descricao"].ToString(),
                                Duracao = int.Parse(row["Duracao"].ToString())
                            };
                            receitas.Add(a);
                        }
                    }
                }
                return receitas;
            }
        }







        public bool remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool Update(string key, Receita obj)
        {
            bool updated = false;
            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Receita Set Duracao==Duracao WHERE idReceita==idReceita";

                command.Parameters.Add("@Duracao", SqlDbType.Decimal).Value = obj.Duracao;
                command.Parameters.Add("@idReceita", SqlDbType.Int).Value = obj.idReceita;

                if (command.ExecuteNonQuery() > 0)
                {
                    updated = true;
                }
            }
            return updated;
        }

    }
}
