using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Blog.Bus;
using Blog.Command.Commands.Post;
using Blog.Extensions;
using Blog.Query;
using Blog.Query.Models.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private readonly Lazy<IPostsRepository> _postsRepo;
        private ICommandBus _commandBus;

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

        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            return View("AddEditPost", new Post());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _commandBus.ProcessCommand(new AddPost(post.CategoryId, post.Title, post.Description, post.Content.Replace("\r", "").Replace("\n", "<br />"), DateTime.Now, HttpContext.User.GetUserId().Value));
                return RedirectToAction("Posts","Dashboard");
            }
            ViewBag.Action = "Create";
            return View("AddEditPost", post);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            return View("AddEditPost", new Post());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                //
                return RedirectToAction("Posts","Dashboard");
            }
            ViewBag.Action = "Edit";
            return View("AddEditPost", post);
        }
    }
}
