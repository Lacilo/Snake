using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Snake.Models;
using Snake.View;

namespace Snake.Controller
{
    internal class SnakeController
    {
        public static bool IsCollided(SnakePos snake, SnakeView view)
        {
            if (snake.Positions.Any(x => x.X == snake.Positions.Last().X && snake.Positions.Last().Y == x.Y && x != snake.Positions.Last()))
            {
                return true;
            }

            return false;
        }

        public static void IncreaseLength(SnakePos snake)
        {
            snake.MaxSnakeLength++;
        }

        public static void AppendSnake(SnakePos snake, char direction, Pos currentFruitPos)
        {
            if (snake.MaxSnakeLength < snake.Positions.Count)
            {
                snake.Positions.RemoveAt(0);
            }

            switch (direction)
            {
                case 'w':
                    snake.Positions.Add(new Pos(snake.Positions.Last().X, snake.Positions.Last().Y - 1));
                    Console.WriteLine("Hosszabbítottam a kígyót - w");
                    snake.Positions.ForEach(x => Console.WriteLine(x.X + " " + x.Y));

                    break;

                case 's':
                    if(snake.Positions.Last().X == currentFruitPos.X && snake.Positions.Last().Y + 1 == currentFruitPos.Y) snake.MaxSnakeLength++;

                    snake.Positions.Add(new Pos(snake.Positions.Last().X, snake.Positions.Last().Y + 1));
                    Console.WriteLine("Hosszabbítottam a kígyót - s");
                    snake.Positions.ForEach(x => Console.WriteLine(x.X + " " + x.Y));

                    break;

                case 'a':
                    if (snake.Positions.Last().X == currentFruitPos.X - 1 && snake.Positions.Last().Y == currentFruitPos.Y) snake.MaxSnakeLength++;

                    snake.Positions.Add(new Pos(snake.Positions.Last().X - 1, snake.Positions.Last().Y));
                    Console.WriteLine("Hosszabbítottam a kígyót - a");
                    snake.Positions.ForEach(x => Console.WriteLine(x.X + " " + x.Y));

                    break;

                case 'd':
                    if (snake.Positions.Last().X == currentFruitPos.X + 1 && snake.Positions.Last().Y == currentFruitPos.Y) snake.MaxSnakeLength++;

                    snake.Positions.Add(new Pos(snake.Positions.Last().X + 1, snake.Positions.Last().Y));
                    Console.WriteLine("Hosszabbítottam a kígyót - d");
                    snake.Positions.ForEach(x => Console.WriteLine(x.X + " " + x.Y));

                    break;
            }
        }
    }
}
