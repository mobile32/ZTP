using Blog.Bus;
using Blog.Write.Commands.User;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class AuthController : Controller
    {
        private readonly ICommandBus commandBus;

        public AuthController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null)
            {
                commandBus.ProcessCommand(new Login(username, password));
            }
            return RedirectToAction("Index", "Post");
        }

        public IActionResult Register(string username, string password)
        {
            if (username != null && password != null)
            {
                commandBus.ProcessCommand(new RegisterNewUser(username, password, password));
            }
            return RedirectToAction("Index", "Post");
        }
    }
}