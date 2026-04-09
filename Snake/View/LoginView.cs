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

        
    }
}
