using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial_Seguros.DAL;

namespace Trial_Seguros.Model
{
    public class Controls
    {
        public bool canAcess;
        public string error_msg = "";
        public bool acess(string user, string password)
        {
            loginDaoCommands loginDao = new loginDaoCommands();
            canAcess = loginDao.verifyLogin(user, password);

            if (!loginDao.error_msg.Equals(""))
            {
                this.error_msg = loginDao.error_msg;
            }
            return canAcess;
        }

        public String newuser(string user_name, string user_password, string confUser_password)
        {
            return error_msg;
        }
    }
}
