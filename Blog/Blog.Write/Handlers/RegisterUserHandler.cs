using Blog.Bus;
using Blog.Context;
using Blog.Write.Commands;
using Blog.Write.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Write.Handlers
{
    class RegisterUserHandler : IHandler<RegisterNewUser>
    {
        private readonly BlogContext db;

        public RegisterUserHandler(BlogContext db)
        {
            this.db = db;
        }
        public void ExecuteCommand(RegisterNewUser command)
        {
            if (command.Password != command.ConfirmPassword) throw new PasswordsDontMatchException();

            var username = command.Username.Trim();
            var user = db.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
            if (user != null) throw new UsernameTakenException();

            db.Users.Add(new Context.Models.User
            {
                Username = command.Username,
                IsActive = true,
                Password = new PasswordService().HashPassword(command.Password)
            });

            db.SaveChanges();
        }
    }
}
