﻿using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using JARVIS.Models;
using System.Collections.Generic;

namespace JARVIS.DataAccess
{
    public class ReceitaDAO : IDAO<Receita>
    {
        private IConnection _connection;

        public ReceitaDAO(IConnection connection)
        {
            _connection = connection;
        }

        public Receita FindById(int key)
        {
            Receita r = new Receita();
            int ind = 0;
            using (SqlConnection con = _connection.Fetch())
            {
                string query = "SELECT * FROM Receita where idReceita=@idReceita";
                var dt = new DataTable();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@idReceita", key.ToString());
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

                String query2 = "SELECT * FROM Receita_Alimento where idReceita=@idReceita";
                DataTable dt2 = new DataTable();

                using (SqlCommand command2 = new SqlCommand(query2, con))
                {
                    command2.Parameters.AddWithValue("@idReceita", key.ToString());
                    SqlDataReader reader2 = command2.ExecuteReader();
                    dt2.Load(reader2);
                    reader2.Close();

                    foreach (DataRow row2 in dt2.Rows)
                    {
                        ind = int.Parse(row2["Indispensável"].ToString());
                        if (ind > 0)
                            r.indispensaveis.Add(int.Parse(row2["idAlimento"].ToString()));
                    }
                }


                List<Alimento> alimentos = new List<Alimento>();
                alimentos = ListaAlimentos(con, key);
                r.Ingredientes = alimentos;


                List<Passo> passos = new List<Passo>();
                passos = ListaPassos(con, key);
                r.Passos = passos;
            }

            return r;
        }


        public Receita FindByName(string key)
        {
            throw new NotImplementedException();
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
                           int id = int.Parse(row["idReceita"].ToString());
                            List<Alimento> alimentos = ListaAlimentos(con, id);
                            a.Ingredientes = alimentos;
                            receitas.Add(a);
                        }
                    }
                }
                return receitas;
            }
        }




        public List<Alimento> ListaAlimentos(SqlConnection con, int id)
        {
            List<Alimento> alimentos = new List<Alimento>();

            string query = "SELECT * FROM Receita_Alimento WHERE idReceita =@id";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@id", id.ToString());

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = command;
                    DataSet tab = new DataSet();
                    adapter.Fill(tab);

                    foreach (DataTable table in tab.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            string alimento = row["idAlimento"].ToString();
                            string quantidade = row["Quantidade"].ToString();
                            string query2 = "SELECT * FROM Alimento where idAlimento = @idAl";
                            using (SqlCommand command2 = new SqlCommand(query2, con))
                            {
                                command2.Parameters.AddWithValue("@idAl", alimento);
                                using (SqlDataAdapter adapter2 = new SqlDataAdapter())
                                {
                                    adapter2.SelectCommand = command2;
                                    DataSet tab2 = new DataSet();
                                    adapter2.Fill(tab2);

                                    foreach (DataTable table2 in tab2.Tables)
                                    {
                                        foreach (DataRow row2 in table2.Rows)
                                        {
                                            Alimento a = new Alimento
                                            {
                                                idAlimento = int.Parse(row2["idAlimento"].ToString()),
                                                Nome = row2["Nome"].ToString(),
                                                ValorNutricional = double.Parse(row2["ValorNutricional"].ToString()),
                                                Validade = DateTime.Parse(row2["Validade"].ToString()),
                                                Quantidade = quantidade
                                            };
                                            alimentos.Add(a);
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            return alimentos;
        }


        public List<Passo> ListaPassos(SqlConnection con, int id)
        {
            List<Passo> passos = new List<Passo>();

            string query = "SELECT * FROM Instrução WHERE idReceita =@id";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = command;
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
                                idReceita = int.Parse(row["idReceita"].ToString()),
                                Ordem = int.Parse(row["Ordem"].ToString()),
                                imagem = (byte[])row["imagem"],
                                video = row["video"].ToString()


                        };
                            passos.Add(p);
                        }
                                    

                    }
                }
            }
            return passos;
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
