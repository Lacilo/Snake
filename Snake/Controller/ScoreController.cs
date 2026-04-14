using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Snake.Models;

namespace Snake.Controller
{
    internal class ScoreController
    {
        public bool ScoreToDatabase(int score, string PlayerName, DateTime ScoreDate)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=;database=snake;");
                con.Open();
                string insertSql = @"INSERT INTO high_score VALUES (@Name,@Score,@ScoreDate)";
                MySqlCommand insertcmd = new MySqlCommand(insertSql, con);
                insertcmd.Parameters.AddWithValue("@Name", PlayerName);
                insertcmd.Parameters.AddWithValue("@Score", score);
                insertcmd.Parameters.AddWithValue("@ScoreDate", ScoreDate);


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

        public Score GetPlayerScore(string PlayerName)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=snake;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "SELECT Score FROM high_score WHERE Name = @Name";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", PlayerName);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Score()
                    {
                        PlayerScore = reader.GetInt32("Score"),
                    };
                }
                connection.Close();
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt: " + ex.Message);
                return null;
            }
        }
    }
}

