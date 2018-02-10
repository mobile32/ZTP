using System;
using System.Linq;
using Blog.Bus;
using Blog.Command.Commands.User;
using Blog.Command.Events.User;
using Blog.Command.Exceptions;
using Blog.DAL;

namespace Blog.Command.Handlers.User
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
            var username = command.Username.Trim();
            var user = db.Users.FirstOrDefault(x => x.IsActive && x.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                eventBus.PublishEvent(new InvalidUserLoginAttempt(command.Username, command.Password));
                throw new InvalidLoginException();
            }
            var passwordService = new PasswordService();

            var passwordHash = passwordService.HashPassword(command.Password, user.Salt);

            if (passwordHash != user.Password)
            {
                eventBus.PublishEvent(new FailedLoginAttempt(command.Username, command.Password));
                throw new InvalidPasswordException();
            }

            eventBus.PublishEvent(new UserLoggedIn(user.Id, user.Username, DateTime.Now));
        }
    }
}
