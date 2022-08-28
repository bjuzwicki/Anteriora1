using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anteriora
{
    class SQLConnection
    {
        string connectionString = @"Server=tcp:anteriorasqlserver.database.windows.net,1433;Initial Catalog=AnterioraDatabase;Persist Security Info=False;User ID=bartlomiej.juzwicki;Password=PROKox12astral13;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int RunSQL(string query)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                SqlCommand command = new SqlCommand(query, cn);

                int value = command.ExecuteNonQuery();

                cn.Close();

                return value;
            }

        }
        public object GetField(string field, string table, string where)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = string.Format("SELECT {0} FROM {1} WHERE {2}", field, table, where); //FIRST 1
                var value = "";

                cn.Open();

                SqlCommand command = new SqlCommand(query, cn);

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    value = dataReader.GetValue(0).ToString();
                }

                cn.Close();

                return value;
            }
        }

        public DataTable GetCharacterList(int userREF)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = string.Format("SELECT characters.NAME as Nazwa, classes.NAME as Klasa, LEVEL as Poziom, EXP as PD, STRENGTH as Siła, DEXTERITY as Zręczność, INTELLIGENCE as Inteligencja, VITALITY as Witalność FROM USER_CHARACTERS characters JOIN CHARACTER_CLASSES classes on characters.CLASS = classes.REF WHERE characters.USER_REF = {0} ORDER BY NUMBER", userREF);

                cn.Open();

                SqlDataAdapter sqlData = new SqlDataAdapter(query, cn);

                DataTable dtbl = new DataTable();

                sqlData.Fill(dtbl);

                cn.Close();

                return dtbl; 
            }
        }

        public void GetCharacterData(int userREF,int whichCharacter)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = string.Format("SELECT REF, NAME, CLASS, LEVEL, EXP, STRENGTH, DEXTERITY, INTELLIGENCE, VITALITY FROM USER_CHARACTERS WHERE USER_REF = {0} AND NUMBER = {1}",userREF,whichCharacter); //FIRST 1

                cn.Open();

                SqlCommand command = new SqlCommand(query, cn);

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    new Character((int)dataReader.GetValue(0), dataReader.GetValue(1).ToString(), (int)dataReader.GetValue(2), (int)dataReader.GetValue(3), (int)dataReader.GetValue(4), (int)dataReader.GetValue(5), (int)dataReader.GetValue(6), (int)dataReader.GetValue(7), (int)dataReader.GetValue(8));
                }

                cn.Close();
            }
        }

        public int SetCharacterData(int characterType, string name)
        {
            string numberString = GetField("NUMBER", "USER_CHARACTERS", "USER_REF = " + User.REF + " ORDER BY NUMBER DESC").ToString();
            int number = 0;

            if (!string.IsNullOrEmpty(numberString))
            {
                number = Convert.ToInt32(numberString);
            }

            //try
            //{
            //    number = Convert.ToInt32(GetField("NUMBER", "USER_CHARACTERS", "USER_REF = " + User.REF + " ORDER BY NUMBER DESC") ?? 0);
            //}
            //catch
            //{
            //    number = 0;
            //}

            number += 1;

            List<int> attrubites = GetBasicAttribute(characterType);

            string query = string.Format("INSERT INTO USER_CHARACTERS(USER_REF,NUMBER,NAME, CLASS, LEVEL, EXP, STRENGTH, DEXTERITY, INTELLIGENCE, VITALITY) VALUES ({0},{1},'{2}',{3},{4},{5},{6},{7},{8},{9})", User.REF, number, name, characterType, 1, 0, attrubites[0], attrubites[1], attrubites[2], attrubites[3]);

            if(RunSQL(query) < 0)
            {
                return -1;
            }

            return number;
        }

        public List<int> GetBasicAttribute(int characterType)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = string.Format("SELECT BASIC_STRENGTH,BASIC_DEXTERITY,BASIC_INTELLIGENCE,BASIC_VITALITY FROM CHARACTER_CLASSES WHERE REF = {0}", characterType);

                cn.Open();

                SqlCommand command = new SqlCommand(query, cn);

                SqlDataReader dataReader = command.ExecuteReader();

                List<int> attributes = new List<int>();

                if (dataReader.Read())
                {
                    
                    attributes.Add((int)dataReader.GetValue(0));
                    attributes.Add((int)dataReader.GetValue(1));
                    attributes.Add((int)dataReader.GetValue(2));
                    attributes.Add((int)dataReader.GetValue(3));
                }

                cn.Close();

                return attributes;
            }
        }

        public bool VerifyLogin(string login)
        {
            SQLConnection cn = new SQLConnection();

            string userREF = cn.GetField("REF", "USERS", "LOGIN = '" + login + "'").ToString();

            if (string.IsNullOrEmpty(userREF))
            {
                return true; // nie ma takiego loginu w tabeli
            }
            else
            {
                return false; // istnieje taki login w bazie
            }
        }

        public bool VerifyLoginAndPassword(string login, string password)
        {
            SQLConnection cn = new SQLConnection();

            string getPassword = cn.GetField("PASSWORD", "USERS", "LOGIN = '" + login + "'").ToString();

            if (string.IsNullOrEmpty(getPassword))
            {
                return false; // brak loginu w tabeli Users
            }
            else
            {
                if (getPassword == password)
                {
                    //SetUserID();
                    return true;  // dane logowania prawidłowe
                }
                else
                {
                    return false; // hasło nieprawidłowe
                }
            }
        }

        public DataTable LoadGame(int characterREF)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = string.Format("SELECT * FROM SAVES WHERE USER_CHARACTER = {0} ORDER BY REF DESC", characterREF);

                cn.Open();

                SqlDataAdapter sqlData = new SqlDataAdapter(query, cn);

                DataTable dtbl = new DataTable();

                sqlData.Fill(dtbl);

                cn.Close();

                return dtbl;
            }
        }

        //public Dictionary<string, string> GetValuesToChart(int userREF)
        //{
        //    Dictionary<string, string> dictionary = new Dictionary<string, string>();

        //    using (SqlConnection cn = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT measureDate, userWeight from History where userREF = " + userREF + " order by measureDate asc";

        //        cn.Open();

        //        SqlCommand command = new SqlCommand(query, cn);

        //        SqlDataReader dataReader = command.ExecuteReader();

        //        while (dataReader.Read())
        //        {
        //            try
        //            {
        //                dictionary.Add(dataReader.GetValue(0).ToString(), dataReader.GetValue(1).ToString()); //uzupelniamy slownik o wartosc daty i wagi
        //            }
        //            catch
        //            {
        //                continue;           // pomijamy, jesli juz taki rekord juz istnieje w slowniku    
        //            }

        //        }

        //        cn.Close();

        //        return dictionary;
        //    }

        //    foreach (KeyValuePair<string, string> kvp in dictionary)
        //    {
        //        chart...."kvp.Key", "kvp.Value"
        //    }
        //}
    }
}
