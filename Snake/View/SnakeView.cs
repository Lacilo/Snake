using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Snake.Models;

namespace Snake.View
{
    internal class SnakeView
    {
        public SnakeView() { }

        public SnakeView(int[,] map)
        {
            Map = map;
        }

        public int[,] Map;

        public void DisplayMapFlicker(int score)
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    if (Map[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("█");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (Map[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("█");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (Map[i, j] == 0)
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("|\n");
            }
            for (int i = 0; i < Map.GetLength(1); i++)
            {
                Console.Write('-');
            }
            //Console.WriteLine("\nPontszám: " + score);
        }

        public void HighlihtSnakeHead(SnakePos snake)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(snake.Positions.Last().X, snake.Positions.Last().Y);
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayMapElements(SnakePos snake, Pos currentFruitPos, int mapHeight)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(snake.Positions.Last().X, snake.Positions.Last().Y);
            Console.Write("▒");

            Console.SetCursorPosition(snake.Positions[0].X, snake.Positions[0].Y);
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(currentFruitPos.X, currentFruitPos.Y);
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, mapHeight);
            Console.Write("Pontszám: " + (snake.MaxSnakeLength - 5));
        }

        public void DisplayWholeSnake(SnakePos snake, Pos currentFruitPos)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in snake.Positions)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write("▒");
            }

            Console.SetCursorPosition(snake.Positions[0].X, snake.Positions[0].Y);
            Console.Write(" ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(currentFruitPos.X, currentFruitPos.Y);
            Console.Write("■");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayMap(int score)
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    if (Map[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("█");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (Map[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("█");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if(Map[i, j] == 0)
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("|\n");
            }
            for (int i = 0; i < Map.GetLength(1); i++)
            {
                Console.Write('-');
            }
            Console.WriteLine("\n\nPontszám: " + score);
        }

        public void InsertSnakeIntoMap(SnakePos sPos)
        {
            Map = new int[Map.GetLength(0), Map.GetLength(1)];

            foreach (var item in sPos.Positions)
            {
                Map[item.Y, item.X] = 1;
            }
        }

        public void InsertNewFruitIntoMap(Pos fPos)
        {
            if(fPos.X > -1) Map[fPos.Y, fPos.X] = 2;
        }   
    }
}
