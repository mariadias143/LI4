using System;
using System.Data;
using System.Data.SqlClient;

namespace JARVIS.DataAccess
{
    public class Connection : IConnection
    {
        private SqlConnection _connection;

        public Connection()
        {
            _connection = new SqlConnection("Data Source=localhost; database=jarvis;" + "User ID=root; Password = root");
        }

        public void close()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlConnection Fetch()
        {
            if (_connection.State == ConnectionState.Open)
            {
                return _connection;
            }
            else
            {
                return this.Open();
            }
        }

        public SqlConnection Open()
        {
            _connection.Open();
            return _connection;
        }
    }
}
