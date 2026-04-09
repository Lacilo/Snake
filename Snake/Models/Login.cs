using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    internal class Login
    {
        public Login(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public Login() { }

        public string UserName { get; set; }
        public string Password { get; private set; }
    }
}
