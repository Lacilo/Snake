using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.View
{
    internal class UserView
    {
        public static void UserMenu()
        {
            bool b = true;
            while (b)
            {
                Console.Clear();
                Console.WriteLine("=== Menü ===");
                Console.WriteLine("1. Regisztráció");
                Console.WriteLine("2. Bejelentkezés");
                Console.WriteLine("3.");
                Console.WriteLine("4. Kilépés");
                int answer = int.Parse(Console.ReadLine());


                switch (answer)
                {
                    case 1:
                        LoginView.RegistrationView();
                        break;
                    case 2:
                        LoginView.BejelentkezesView();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
