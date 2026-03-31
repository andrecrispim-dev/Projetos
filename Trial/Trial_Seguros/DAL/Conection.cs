using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial_Seguros.DAL
{
    public class Conection
    {
        SqlConnection connection = new SqlConnection();
        public Conection()
        {
            connection.ConnectionString = @"Data Source=localhost;Initial Catalog=Trial_sql;Persist Security Info=True;User ID=SA;Password=109400";            
        }

        public SqlConnection connect()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        public void desconnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
