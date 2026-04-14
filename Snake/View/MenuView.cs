using Snake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.View
{
    internal class MenuView
    {
        public static void DisplayMainMenu(ref Login currentUser)
        {
            // Bejelentkezés/regisztráció
            Console.Clear();
            Console.WriteLine("Bejelentkezés - 1 ");
            Console.WriteLine("Regisztráció - 2");
            Console.WriteLine("Kilépés - 3");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                currentUser = LoginView.BejelentkezesView();
            }
            else if (choice == "2")
            {
                LoginView.RegistrationView();
            }
            else if (choice == "3")
            {
                Environment.Exit(0);
            }
        }
    }
}
