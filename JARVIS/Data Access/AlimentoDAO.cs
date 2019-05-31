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

        public Alimento FindById(string key)
        {
            throw new NotImplementedException();
        }

        public Alimento Insert(Alimento obj)
        {
            //SqCommand command ...
            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Alimento values (@idAlimento,@Nome,@ValorNutricional,@Validade)";

                command.Parameters.Add("@idAlimento", SqlDbType.Int).Value = obj.idAlimento;
                command.Parameters.Add("@Nome", SqlDbType.Text).Value = obj.Nome;
                command.Parameters.Add("@ValorNutricional", SqlDbType.Text).Value = obj.ValorNutricional;
                command.Parameters.Add("@Validade", SqlDbType.Date).Value = obj.Validade;

                command.ExecuteNonQuery();
                // obj.Id = command.ExecuteScalar().ToString(); -> devolve o valor da primeira linha e primeira coluna da tabela em questão
                //
            }
            return obj;
        }

        public Collection<Alimento> ListAll()
        {
            Collection<Alimento> alimentos = new Collection<Alimento>();
            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT idAlimento, Nome, ValorNutricional, Validade";

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable tab = new DataTable();
                    adapter.Fill(tab);

                    foreach (DataRow row in tab.Rows)
                    {
                        Alimento a = new Alimento
                        {
                            idAlimento = int.Parse(row["idAlimento"].ToString()),
                            Nome = row["Nome"].ToString(),
                            ValorNutricional = double.Parse(row["ValorNutricional"].ToString()),
                            Validade = DateTime.Parse(row["Validade"].ToString())
                        };
                        alimentos.Add(a);
                    }
                }
                return alimentos;
            }
        }

        public bool remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool Update(string key, Alimento obj)
        {
            bool updated = false;
            using (SqlCommand command = _connection.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Alimento Set ValorNutricional==ValorNutricional WHERE idAlimento==idAlimento";

                command.Parameters.Add("@ValorNutricional", SqlDbType.Decimal).Value = obj.ValorNutricional;
                command.Parameters.Add("@idAlimento", SqlDbType.Int).Value = obj.idAlimento;

                if (command.ExecuteNonQuery() > 0)
                {
                    updated = true;
                }
            }
            return updated;
        }
    }
}
