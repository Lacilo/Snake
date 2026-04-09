using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using Snake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Controller
{
    internal class UserController
    {
        public List<Login> GetLoginList()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=;database=snake;");
                conn.Open();
                string comd = "SELECT * FROM bejelentkezes;";
                MySqlCommand cmd = new MySqlCommand(comd, conn);
                List<Login> connections = new List<Login>();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        connections.Add(new Login(
                            reader.GetString("FelhNev"),
                            reader.GetString("Jelszo")
                        ));
                    }

                    conn.Close();
                    return connections;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool NewRegistration(string nev, string jelszo)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=;database=snake;");
                con.Open();
                string insertSql = @"INSERT INTO bejelentkezes VALUES (@FelhNev,@Jelszo)";
                MySqlCommand insertcmd = new MySqlCommand(insertSql, con);
                insertcmd.Parameters.AddWithValue("@FelhNev", nev);
                insertcmd.Parameters.AddWithValue("@Jelszo", jelszo);


                int sorok = insertcmd.ExecuteNonQuery();
                bool valasz = sorok > 0 ? true : false;
                return valasz;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool IsLoginTrueOrFalse(string name, string password)
        {
            var logins = GetLoginList();
            foreach (var login in logins)
            {
                if (login.UserName == name && login.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
