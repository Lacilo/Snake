using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Models;

namespace Snake.Controller
{
    internal class SnakeController
    {
        public static void AppendSnake(SnakePos snake, char direction)
        {
            switch (direction)
            {
                case 'w':
                    snake.Positions.Add(new Pos(snake.Positions.Last().X, snake.Positions.Last().Y - 1));
                    break;
                case 's':
                    snake.Positions.Insert(0, new Pos(snake.Positions[0].X, snake.Positions[0].Y + 1));
                    Console.WriteLine("Hosszabbítottam a kígyót");
                    snake.Positions.ForEach(x => Console.WriteLine(x.X + " " + x.Y));
                    break;
            }
        }
    }
}
