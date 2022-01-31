using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PizzaDALLibrary
{
    //singleton class- only able to create one obj of this class
    internal class MyConnection
    {
        SqlConnection conn;
        static MyConnection connection;
        private  MyConnection()   //call only once
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }
        public static SqlConnection GetConnection()
        {
            if (connection == null)
                connection = new MyConnection();
            return connection.conn;
        }
    }
}
