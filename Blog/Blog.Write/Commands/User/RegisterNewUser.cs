using Blog.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Write.Commands.User
{
    public class RegisterNewUser: ICommand
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }

        public RegisterNewUser(string username, string password, string confirmPassword)
        {
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
