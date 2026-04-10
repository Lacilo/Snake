using Google.Protobuf.WellKnownTypes;
using Snake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Controller
{
    internal class FruitController
    {
        public bool IsEaten(SnakePos snake, Pos currentFruitPos, char dir)
        {
            if (snake.Positions.Last().X == currentFruitPos.X && snake.Positions.Last().Y == currentFruitPos.Y) return true;

            return false;
        }

        public Pos GenerateRandomFruitPos(SnakePos snake, int xMax, int yMax)
        {
            Random rnd = new Random();
            int x = rnd.Next(0, xMax);
            int y = rnd.Next(0, yMax);

            while (snake.Positions.Any(pos => pos.X == x && pos.Y == y))
            {
                rnd = new Random();
                x = rnd.Next(0, xMax);
                y = rnd.Next(0, yMax);
            }

            return new Pos(x, y);
        }
    }
}
