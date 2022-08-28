using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteriora
{
    class User
    {
        public static int REF { get; set; }
        public static string login { get; set; }
        public static string email { get; set; }

        public User(string userLogin, string userEmail)
        {
            login = userLogin;
            email = userEmail;

            REF = SetUserREF();
        }

        public User(string userLogin)
        {
            login = userLogin;

            email = SetUserEmail();
            REF = SetUserREF();
        }

        public int SetUserREF()
        {
            SQLConnection sql = new SQLConnection();

            return Convert.ToInt32(sql.GetField("REF", "USERS", "LOGIN = '" + login + "'"));
        }

        public string SetUserEmail()
        {
            SQLConnection sql = new SQLConnection();

            return sql.GetField("EMAIL", "USERS", "LOGIN = '" + login + "'").ToString();
        }
    }
}
