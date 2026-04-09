using MySql.Data.MySqlClient;
using Snake.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.View
{
    internal class LoginView
    {
        static void RegistrationView()
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
                    new UserController().NewRegistration(felhNev,jelszo);
                    Console.WriteLine("Sikeres regisztráció!");
                    Console.ReadLine();
                    b = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }        
            }
        }

        static void BejelentkezesView()
        {
            bool b = true;
            while (b)
            {
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
                    Console.ReadLine();
                    b = false; 
                }
                else
                {
                    Console.WriteLine("Hibás felhasználónév vagy jelszó!");
                    Console.ReadLine();
                }  
            }
        }
    }
}
