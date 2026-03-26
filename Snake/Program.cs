using System;
using Snake.Models;
using Snake.View


namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SnakeView view = new SnakeView();
            Snake snake = new Snake();

            view.DisplayMap();
        }
    }
}