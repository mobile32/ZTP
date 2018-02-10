using Blog.Bus;
using Blog.Read;
using Blog.Write.Commands.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class AuthService
    {
        private readonly ICommandBus commandBus;
        private readonly IUsersRepository usersRepository;

        public AuthService(ICommandBus commandBus, IUsersRepository usersRepository)
        {
            this.commandBus = commandBus;
            this.usersRepository = usersRepository;
        }

        public ClaimsIdentity Register(string username, string password, string confirmPassword)
        {
            commandBus.ProcessCommand(new RegisterNewUser(username, password, confirmPassword));
            return Login(username, password);
        }

        public ClaimsIdentity Login(string username, string password)
        {
            commandBus.ProcessCommand(new Login(username, password));

            var user = usersRepository.GetUser(username);

            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim("UserId", user.Id.ToString())
                    };

            return new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
