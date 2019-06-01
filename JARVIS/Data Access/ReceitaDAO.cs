﻿using System;
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
            Receita r = new Receita();
            using (SqlConnection con = _connection.Fetch())
            {
                string query = "SELECT * FROM Receita where idReceita=@idReceita";
                var dt = new DataTable();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@idReceita", key);
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        r.idReceita = int.Parse(row["idReceita"].ToString());
                        r.Nome = row["Nome"].ToString();
                        r.Descricao = row["Descricao"].ToString();
                        r.Classificacao = float.Parse(row["Classificacao"].ToString());
                        r.Dificuldade = row["Dificuldade"].ToString();
                        r.Duracao = int.Parse(row["Duracao"].ToString());
                    }
                }
            }
            return r;
        }





        public Receita Insert(Receita obj)
        {
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "INSERT INTO dbo.Receita(Nome,Descricao,Dificuldade,Classificacao,Duracao) values (@Nome,@Descricao,@Dificuldade,@Classificacao,@Duracao)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = obj.Nome ?? (object)DBNull.Value;
                    command.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = obj.Descricao;
                    command.Parameters.Add("@Duracao", SqlDbType.Int).Value = obj.Duracao;
                    command.Parameters.Add("@Dificuldade", SqlDbType.VarChar).Value = obj.Dificuldade;
                    command.Parameters.Add("@Classificacao", SqlDbType.Decimal).Value = obj.Classificacao;

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
                                Dificuldade = row["Dificuldade"].ToString(),
                                Classificacao = float.Parse(row["Classificacao"].ToString()),
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
                string queryString = "SELECT Alimento_idAlimento FROM Receita_Alimento WHERE @idReceita = id";
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
            bool removed = false;
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "DELETE FROM dbo.Receita where idReceita=@idReceita";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@idReceita", key);
                    if (command.ExecuteNonQuery() > 0)
                    {
                        removed = true;
                    }
                }
            }
            return removed;
        }



        public bool Update(string key, Receita obj)
        {
            bool updated = false;
            using (SqlConnection con = _connection.Fetch())
            {
                String query = "UPDATE dbo.Receita SET Nome=@Nome, Descricao=@Descricao, Dificuldade=@Dificuldade, Classificacao=@Classificacao, Duracao=@Duracao WHERE idReceita=@idReceita";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Nome", obj.Nome);
                    command.Parameters.AddWithValue("@Descricao", obj.Descricao);
                    command.Parameters.AddWithValue("@Dificuldade", obj.Dificuldade);
                    command.Parameters.AddWithValue("@Classificacao", obj.Classificacao);
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
