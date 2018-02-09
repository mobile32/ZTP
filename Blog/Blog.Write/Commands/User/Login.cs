using Blog.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Write.Commands.User
{
    public class Login: ICommand
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
