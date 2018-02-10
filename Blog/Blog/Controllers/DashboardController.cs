using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Bus;
using Blog.Command.Commands.Post;
using Blog.Extensions;
using Blog.Query;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IPostsRepository _postsRepository;

        public DashboardController(ICommandBus commandBus, IPostsRepository postsRepository)
        {
            _commandBus = commandBus;
            _postsRepository = postsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Posts()
        {
            return View(_postsRepository.GetPostsForDashboard());
        }

        public IActionResult Categories()
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