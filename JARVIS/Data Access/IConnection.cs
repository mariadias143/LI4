using System;
using System.Data.SqlClient;

namespace JARVIS.DataAccess
{
    public interface IConnection
    {
        //Open our connection
        //SqlConnection Open() <- SqlServer
        SqlConnection Open();

        //Fetch our connection, If not created then create
        SqlConnection Fetch();

        void close();
    }
}
