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

        public void HighlightSnakeHead(SnakePos snake, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(snake.Positions.Last().X, snake.Positions.Last().Y);
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayMapElemets(SnakePos snake, Pos currentFruitPos, int mapHeight, int userRecord)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in snake.Positions)
            {
                if (item == snake.Positions.Last()) 
                {
                    Console.SetCursorPosition(item.X+1, item.Y+1);
                    Console.Write("█");
                }
                else 
                {
                    Console.SetCursorPosition(snake.Positions[0].X+1, snake.Positions[0].Y+1);
                    Console.Write(" ");

                    Console.SetCursorPosition(item.X+1, item.Y+1);
                    Console.Write("▒");
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(currentFruitPos.X+1, currentFruitPos.Y+1);
            Console.Write("■");

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, mapHeight);
            Console.Write("Pontszám: " + (snake.MaxSnakeLength - 5) + $" | Előző Rekord: {userRecord}");
        }

        public void DisplayMap(int score)
        {
            Console.Write(" ");
            for (int i = 0; i < Map.GetLength(1); i++)
            {
                Console.Write('-');
            }

            Console.WriteLine();

            for (int i = 0; i < Map.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Console.Write(" ");
                }
                Console.Write("|\n");
            }

            Console.Write(" ");
            for (int i = 0; i < Map.GetLength(1); i++)
            {
                Console.Write('-');
            }
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
