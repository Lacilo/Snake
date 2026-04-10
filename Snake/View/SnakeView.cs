using System;
using System.Collections.Generic;
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

        public void DisplayMap()
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Console.Write(Map[i, j] + " ");
                }
                Console.WriteLine();
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
