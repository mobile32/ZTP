using System;
using System.Linq;
using Blog.Bus;
using Blog.Command.Commands.User;
using Blog.Command.Events.User;
using Blog.Command.Exceptions;
using Blog.Context;

namespace Blog.Command.Handlers.User
{
    class RegisterUserHandler : IHandler<RegisterNewUser>
    {
        private readonly IEventBus eventBus;
        private readonly BlogContext db;

        public RegisterUserHandler(IEventBus eventBus, BlogContext db)
        {
            this.eventBus = eventBus;
            this.db = db;
        }
        public void ExecuteCommand(RegisterNewUser command)
        {
            if (command.Password != command.ConfirmPassword) throw new PasswordsDontMatchException();

            var username = command.Username.Trim();
            var user = db.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
            if (user != null) throw new UsernameTakenException();

            var salt = Guid.NewGuid().ToString().Replace("-", "");
            var newUser = new Context.Models.User
            {
                Username = command.Username,
                IsActive = true,
                Password = new PasswordService().HashPassword(command.Password,salt),
                Salt = salt
            };

            db.Users.Add(newUser);
            db.SaveChanges();

            eventBus.PublishEvent(new UserRegistered(newUser.Username, newUser.Password, newUser.Salt));
        }
    }
}
