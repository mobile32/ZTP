using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Blog.Bus;
using Blog.Read;
using Blog.Write.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly Lazy<IPostsRepository> _postsRepo;
        ICommandBus _commandBus;

        public HomeController(ICommandBus commandBus, Lazy<IPostsRepository> postsRepo)
        {
            _postsRepo = postsRepo;
            _commandBus = commandBus;
        }
        public IActionResult Index(int page = 1, int pageSize = 20)
        {
            return View(
                            _postsRepo.Value.GetPostsForList(page, pageSize)
                       );
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            _commandBus.ProcessCommand(new EditPost());

            return View();
        }
    }
}
