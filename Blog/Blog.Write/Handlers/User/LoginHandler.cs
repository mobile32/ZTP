﻿using Blog.Bus;
using Blog.Context;
using Blog.Write.Commands.User;
using Blog.Write.Events.User;
using Blog.Write.Exceptions;
using System;
using System.Linq;

namespace Blog.Write.Handlers.User
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