using Snake.Controller;
using Snake.Models;

namespace Snake.View
{
    internal class LoginView
    {
        public static void RegistrationView()
        {
            bool b = true;
            while (b)
            {
                Console.Clear();
                Console.WriteLine("=== REGISZTRÁCIÓ ===");

                Console.WriteLine("Felhasználónév: ");
                string felhNev = Console.ReadLine();

                Console.WriteLine("Jelszó: ");
                string jelszo = Console.ReadLine();

                try
                {
                    new UserController().NewRegistration(felhNev, jelszo);
                    Console.WriteLine("Sikeres regisztráció!");
                    Console.WriteLine("Nyomjon egy gombot a továbblépéshez!");
                    Console.ReadKey();
                    b = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Valamilyen hiba történt!");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Nyomjon egy gombot a továbblépéshez!");
                    Console.ReadKey();
                }
            }
        }

        public static Login BejelentkezesView()
        {
            bool b = true;
            Console.Clear();
            Console.WriteLine("=== BEJELENTKEZÉS ===");

            Console.WriteLine("Felhasználónév: ");
            string userName = Console.ReadLine();

            Console.WriteLine("Jelszó: ");
            string password = Console.ReadLine();

            bool sucLogin = new UserController().IsLoginTrueOrFalse(userName, password);
            if (sucLogin)
            {
                Console.WriteLine("Sikeres bejelentkezés!");
                Console.WriteLine("Nyomjon egy gombot a továbblépéshez!");
                Console.ReadKey();
                b = false;

                return new Login(userName, password);
            }
            else
            {
                Console.WriteLine("Hibás felhasználónév vagy jelszó!");
                Console.WriteLine("Nyomjon egy gombot a továbblépéshez!");
                Console.ReadKey();

                return null;
            }
        }
    }
}
