using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Bus;
using Blog.Command.Commands.Post;
using Blog.Extensions;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ICommandBus _commandBus;

        public DashboardController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Posts()
        {
            return View();
        }

        public IActionResult Comments()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }
    }
}