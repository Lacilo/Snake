using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Snake.View
{
    internal class SnakeView
    {
        public SnakeView() { }

        public SnakeView(int[,] map)
        {
            Map = map;
        }

        public int[,] Map = new int[20, 20];

        public void DisplayMap()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(Map[i, j] + " | ");
                }
                Console.WriteLine();
            }
        }
    }
}
