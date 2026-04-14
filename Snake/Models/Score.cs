using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    internal class Score
    {
        
        public Score(){ }

        public Score(int id, string playerName ,int playerScore, DateTime scoreDate)
        {
            Id = id;
            PlayerName = playerName;
            PlayerScore = playerScore;
            ScoreDate = scoreDate;
        }

        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int PlayerScore { get; set; }
        public DateTime ScoreDate { get; set; }
    }
}
