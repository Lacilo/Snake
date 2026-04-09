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

        
    }
}
