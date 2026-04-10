using Google.Protobuf.Collections;
using Snake.Controller;
using Snake.Models;
using Snake.View;


namespace MyApp
{
    internal class Program
    {
        static Login currentUser;

        static void Main(string[] args)
        {
            Console.Clear();

            while(true)
            {
                try
                {
                    if(!(currentUser != null))
                    {
                        FruitController fruitController;
                        SnakeView view;
                        SnakePos snake;
                        Pos currentFruitPos;

                        Console.WriteLine("A játékhoz - 1");
                        Console.WriteLine("Az eredményekhez - 2");
                        Console.WriteLine("A kilépéshez - 3\n\nKérem válasszon --> ");
                        string valasztas = Console.ReadLine();

                            if (valasztas == "1")
                            {
                                Console.Clear();
                                InitializeGame(out fruitController, out view, out snake, out currentFruitPos);
                                currentFruitPos = GameLoop(fruitController, view, snake, currentFruitPos);
                            }
                    }
                    else
                    {
                        // Bejelentkezés/regisztráció
                        Console.WriteLine("Bejelentkezés - 1 ");
                        Console.WriteLine("Regisztráció - 2");

                        Console.ReadLine();
                    }
                }
                catch (IndexOutOfRangeException iorEx)
                {
                    Console.WriteLine(iorEx);
                    Console.Clear();
                    Console.WriteLine("Game Over! Eredmények elmentve. Nyomjon entert a főmenübe való visszalépéshez!");
                    Console.ReadLine();
                    Main(null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadLine();
                }                
            }
        }

        private static Pos GameLoop(FruitController fruitController, SnakeView view, SnakePos snake, Pos currentFruitPos)
        {
            Console.Clear();
            view.InsertSnakeIntoMap(snake);
            view.InsertNewFruitIntoMap(currentFruitPos);
            view.DisplayMap(snake.Positions.Count);

            char dir = 'd';

            while (true)
            {      
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.W:
                            dir = 'w';
                            break;
                        case ConsoleKey.A:
                            dir = 'a';
                            break;
                        case ConsoleKey.S:
                            dir = 's';
                            break;
                        case ConsoleKey.D:
                            dir = 'd';
                            break;
                    }
                }

                SnakeController.AppendSnake(snake, dir, currentFruitPos);

                if (fruitController.IsEaten(snake, currentFruitPos, dir))
                {
                    SnakeController.IncreaseLength(snake);
                    currentFruitPos = fruitController.GenerateRandomFruitPos(snake, view.Map.GetLength(1), view.Map.GetLength(0));
                }

                if (SnakeController.IsCollided(snake, view))
                {
                    Console.Clear();
                    Console.WriteLine("Game Over! Eredmények elmentve. Nyomjon entert a főmenübe való visszalépéshez!");
                    Console.ReadLine();
                    Main(null);
                    break;
                }

                view.InsertSnakeIntoMap(snake);
                view.InsertNewFruitIntoMap(currentFruitPos);

                Console.Clear();
                view.DisplayMap(snake.Positions.Count);

                Thread.Sleep(150);
            }

            return currentFruitPos;
        }

        private static void InitializeGame(out FruitController fruitController, out SnakeView view, out SnakePos snake, out Pos currentFruitPos)
        {
            Console.Write("Adja meg a játéktér szélességét és magasságát ebben a formátumban (szél,mag) (pl.: 100,50) --> ");
            string inp = Console.ReadLine();
            string[] inpSplit = inp.Split(',');

            fruitController = new FruitController();
            view = new SnakeView(new int[int.Parse(inpSplit[1]), int.Parse(inpSplit[0])]);
            snake = new SnakePos()
            {
                Positions = new List<Pos>
                {
                    new Pos(0, 0),
                    new Pos(1, 0),
                    new Pos(2, 0),
                    new Pos(3, 0),
                    new Pos(4, 0),
                },

                MaxSnakeLength = 5,
            };

            view.DisplayMap(snake.Positions.Count);
            currentFruitPos = fruitController.GenerateRandomFruitPos(snake, view.Map.GetLength(1), view.Map.GetLength(0));
        }
    }
}