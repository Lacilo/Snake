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
                string insertSql = @"INSERT INTO high_score (Name, Score, ScoreDate) VALUES (@Name,@Score,@ScoreDate)";
                MySqlCommand insertcmd = new MySqlCommand(insertSql, con);
                insertcmd.Parameters.AddWithValue("@Name", PlayerName);
                insertcmd.Parameters.AddWithValue("@Score", score);
                insertcmd.Parameters.AddWithValue("@ScoreDate", ScoreDate);


                int rows = insertcmd.ExecuteNonQuery();
                bool answer = rows > 0 ? true : false;
                return answer;
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
                return new Score() { 
                    PlayerScore = 0,
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt: " + ex.Message);
                return new Score()
                {
                    PlayerScore = 0,
                };
            }
        }

        public bool ScoreUpdateOrInsert(string PlayerName)
        {
            string connectionString = "SERVER=localhost;DATABASE=snake;UID=root;PASSWORD=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = @" SELECT EXISTS(SELECT 1 FROM high_score WHERE Name = @Name);";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", PlayerName);

                    object result = command.ExecuteScalar();

                    return Convert.ToBoolean(result);
                }
            }
        }

        public bool ScoreUpdate(string PlayerName, int PlayerScore, DateTime ScoreDate)
        {
            string connectionString = "SERVER=localhost;DATABASE=snake;UID=root;PASSWORD=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string selectSql = "SELECT Score FROM high_score WHERE Name = @Name";

                using (MySqlCommand selectCmd = new MySqlCommand(selectSql, connection))
                {
                    selectCmd.Parameters.AddWithValue("@Name", PlayerName);

                    object result = selectCmd.ExecuteScalar();

                    int oldScore = result == null ? 0 : Convert.ToInt32(result);

                    if (PlayerScore > oldScore)
                    {
                        string updateSql = "UPDATE high_score SET Score = @Score, ScoreDate = @ScoreDate WHERE Name = @Name";

                        using (MySqlCommand updateCmd = new MySqlCommand(updateSql, connection))
                        {
                            updateCmd.Parameters.AddWithValue("@Score", PlayerScore);
                            updateCmd.Parameters.AddWithValue("@Name", PlayerName);
                            updateCmd.Parameters.AddWithValue("@ScoreDate", ScoreDate);

                            updateCmd.ExecuteNonQuery();
                        }

                        return true;
                    }

                    return false;
                }
            }
        }

        public List<string> ScoreBoard()
        {
            List<string> scoreBoard = new List<string>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(
                    "server=localhost;user=root;password=;database=snake;"))
                {
                    conn.Open();

                    string query = "SELECT Name, Score FROM high_score ORDER BY Score DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            int score = reader.GetInt32(1);

                            scoreBoard.Add($"{name} - {score} pont");
                        }
                    }
                }

                return scoreBoard;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<string>();
            }
        }
    }
}
