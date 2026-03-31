using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial_Seguros.DAL
{
    class loginDaoCommands
    {
        public bool canAcess = false;
        public string error_msg = "";
        SqlCommand sqlcmd = new SqlCommand();
        Conection conection = new Conection();
        SqlDataReader DataReader;
        public bool verifyLogin(string user, string password)
        {
            sqlcmd.CommandText = "SELECT * FROM USERS WHERE USER_NAMES = @user AND USER_PASSWORD = @password";
            sqlcmd.Parameters.AddWithValue("@user", user);
            sqlcmd.Parameters.AddWithValue("@password", password);

            try
            {
                sqlcmd.Connection = conection.connect();
                DataReader = sqlcmd.ExecuteReader();
                if (DataReader.HasRows)
                {
                    canAcess = true;
                }
            }
            catch (SqlException)
            {
                this.error_msg = "Erro com o Banco de Dados!";
            }
            return canAcess;
        }

        public String newuser(string user_name, string user_password, string confUser_password)
        {
            return error_msg;
        }
    }
}
