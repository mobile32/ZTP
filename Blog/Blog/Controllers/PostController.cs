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
    public class PostController : Controller
    {
        private readonly Lazy<IPostsRepository> _postsRepo;
        ICommandBus _commandBus;

        public PostController(ICommandBus commandBus, Lazy<IPostsRepository> postsRepo)
        {
            _postsRepo = postsRepo;
            _commandBus = commandBus;
        }
        public IActionResult Index(int page = 1, int pageSize = 20, int? categoryId=null)
        {
            return View(
                            _postsRepo.Value.GetPostsForList(page, pageSize, categoryId)
                       );
        }

        public IActionResult Details(int id)
        {
            return View(_postsRepo.Value.GetPostWithComments(id));
        }
    }
}
