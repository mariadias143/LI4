using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace JARVIS.DataAccess
{
    public class ReceitaDAO : IDAO<Receita>
    {
        private IConnection _connection;

        public ReceitaDAO(IConnection connection)
        {
            _connection = connection;
        }

        public Receita FindById (string key)
        {

            throw new NotImplementedException();
        }

        public Receita Insert(Receita obj)
        {
            //SqCommand command ...
            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Receita values (@idReceita,@Nome,@Descricao,@Duracao,@Classificacao,@Dificuldade)";

                command.Parameters.Add("@idReceita", SqlDbType.Int).Value = obj.idReceita;
                command.Parameters.Add("@Nome", SqlDbType.Text).Value = obj.Nome;
                command.Parameters.Add("@Descricao", SqlDbType.Text).Value = obj.Descricao;
                command.Parameters.Add("@Duracao", SqlDbType.Int).Value = obj.Duracao;
                command.Parameters.Add("@Classificacao", SqlDbType.Decimal).Value = obj.Classificacao;
                command.Parameters.Add("@Dificuldade", SqlDbType.Text).Value = obj.Dificuldade;

                command.ExecuteNonQuery();
                // obj.Id = command.ExecuteScalar().ToString(); -> devolve o valor da primeira linha e primeira coluna da tabela em questão
                //
            }
            return obj;
        }

        public Collection<Receita> ListAll()
        {
            Collection<Receita> receitas = new Collection<Receita>();

            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT idReceita, Nome, Descricao, Duracao, Classificacao, Dificuldade";

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable tab = new DataTable();
                    adapter.Fill(tab);

                    foreach (DataRow row in tab.Rows)
                    {
                        Receita r = new Receita
                        {
                            idReceita = int.Parse(row["idReceita"].ToString()),
                            Nome = row["Nome"].ToString(),
                            Descricao = row["Descricao"].ToString(),
                            Duracao = int.Parse(row["Duracao"].ToString()),
                            Classificacao = float.Parse(row["Classificacao"].ToString()),
                            Dificuldade = row["Dificuldade"].ToString()
                        };
                        receitas.Add(r);
                    }
                }
                return receitas;
            }
        }

        public bool remove(Receita obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Receita obj)
        {
            bool updated = false;
            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Receita Set Duracao==Duracao WHERE idReceita==idReceita";

                command.Parameters.Add("@Duracao", SqlDbType.Int).Value = obj.Duracao;
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
