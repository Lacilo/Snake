using Snake.Controller;
using Snake.Models;
using Snake.View;


namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SnakeView view = new SnakeView();
            SnakePos snake = new SnakePos()
            {
                Positions = new List<Pos> { new Pos(0, 0), new Pos(1, 0), new Pos(2, 0), new Pos(3, 0), new Pos(4, 0) }
            };

            view.InsertSnakeIntoMap(snake);
            view.DisplayMap();

            SnakeController.AppendSnake(snake, 's');
            view.InsertSnakeIntoMap(snake);
            view.DisplayMap();
        }
    }
}