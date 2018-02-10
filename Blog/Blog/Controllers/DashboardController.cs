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

        public IActionResult CreatePost()
        {
            return View("Post",new PostVM());
        }

        [HttpPost]
        public IActionResult CreatePost(PostVM post)
        {
            _commandBus.ProcessCommand(new AddPost(post.CategoryId,post.Title, post.Description, post.Content.Replace("\r","").Replace("\n","<br />"),DateTime.Now,HttpContext.User.GetUserId().Value));
            return View("Post");
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