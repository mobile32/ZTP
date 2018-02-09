using Blog.Bus;
using Blog.Context;
using Blog.Write.Commands;
using Blog.Write.Events;
using Blog.Write.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Write.Handlers
{
    class LoginHandler : IHandler<Login>
    {
        private readonly BlogContext db;
        private readonly IEventBus eventBus;

        public LoginHandler(BlogContext db, IEventBus eventBus)
        {
            this.db = db;
            this.eventBus = eventBus;
        }
        public void ExecuteCommand(Login command)
        {
            var passwordHash = new PasswordService().HashPassword(command.Password);
            var username = command.Username.Trim();

            var user = db.Users.FirstOrDefault(x => x.IsActive && x.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                eventBus.PublishEvent(new InvalidUserLoginAttempt(command.Username, command.Password));
                throw new InvalidLoginException();
            }
        }
    }
}
