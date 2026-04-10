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
            Console.WriteLine("\nPontszám: " + score);
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
            Console.WriteLine("\nPontszám: " + score);
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
