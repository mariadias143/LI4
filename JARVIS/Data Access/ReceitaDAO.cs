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
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "INSERT INTO dbo.Utilizador(Nome,Descricao,Duracao) values (@Nome,@Descricao,@Duracao)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = obj.Nome ?? (object)DBNull.Value;
                    command.Parameters.Add("@Descricao", SqlDbType.Date).Value = obj.Descricao;
                    command.Parameters.Add("@Duracao", SqlDbType.VarChar).Value = obj.Duracao;

                    command.ExecuteNonQuery();

                }
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




        //PARA JÁ VOU SELECIONAR TODA A TABELA DE UM ALIMENTO E FAZER COM ROWS DEPOIS TENHO DE ALTERAR
        public Collection<Alimento> ListaAlimento(int id) 
        {
            Collection<Alimento> alimentos = new Collection<Alimento>();
            int idAl;

            using (SqlConnection con = _connection.Fetch())
            {
                string queryString = "SELECT Alimento_idAlimento FROM Receita_Alimento WHERE idReceita = id";
                string queryString2 = "SELECT * FROM Alimento where idAlimento = idAl";

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(queryString, con);
                    DataSet tab = new DataSet();
                    adapter.Fill(tab);
                    foreach (DataTable table in tab.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            idAl = int.Parse(row["idAlimento"].ToString());
                            using (SqlDataAdapter adapter2 = new SqlDataAdapter())
                            {
                                adapter2.SelectCommand = new SqlCommand(queryString2, con);
                                DataSet tab2 = new DataSet();
                                adapter.Fill(tab2);

                                foreach (DataTable table2 in tab2.Tables)
                                {
                                    foreach (DataRow row2 in table2.Rows)
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
                            }
                        }
                    }
                }
            }
            return alimentos;
        }






        public bool remove(string key)
        {
            throw new NotImplementedException();
        }



        public bool Update(string key, Receita obj)
        {
            bool updated = false;
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "UPDATE dbo.Receita SET Nome=@Nome, Descricao=@Descricao, Duracao=@Duracao WHERE idUtilizador=@idUtilizador ";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Nome", obj.Nome);
                    command.Parameters.AddWithValue("@Descricao", obj.Descricao);
                    command.Parameters.AddWithValue("@Duracao", obj.Duracao);

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
