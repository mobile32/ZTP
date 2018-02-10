using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Blog.Bus;
using Blog.Command.Commands.Post;
using Blog.Command.Handlers.Post;
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
        private readonly ICommandBus _commandBus;

        public PostController(ICommandBus commandBus, Lazy<IPostsRepository> postsRepo)
        {
            _postsRepo = postsRepo;
            _commandBus = commandBus;
        }
        public IActionResult Index(int page = 1, int pageSize = 20, int? categoryId = null)
        {
            return View(
                            _postsRepo.Value.GetPostsForViewing(page, pageSize, categoryId)
                       );
        }

        public IActionResult Comment(int id, string author, string comment)
        {
            _commandBus.ProcessCommand(new AddCommentToPost(id,author,comment));
            return RedirectToAction("Details", "Post", new {id = id});
        }

        public IActionResult DeleteComment(int id)
        {
            _commandBus.ProcessCommand(new DeleteComment(id));
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Details(int id)
        {
            var post = _postsRepo.Value.GetPostWithComments(id);
            if (post != null)
            {
                return View(post);
            }
            return RedirectToAction("Index");
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
                return RedirectToAction("Posts", "Dashboard");
            }
            ViewBag.Action = "Create";
            return View("AddEditPost", post);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var post = _postsRepo.Value.GetPostById(id);
            if (post != null)
            {
                ViewBag.Action = "Edit";
                return View("AddEditPost", post);
            }
            return RedirectToAction("Posts", "Dashboard");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                _commandBus.ProcessCommand(new EditPost(post.Id, post.CategoryId, post.Title, post.Description, post.Content));
                return RedirectToAction("Posts", "Dashboard");
            }
            ViewBag.Action = "Edit";
            return View("AddEditPost", post);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _commandBus.ProcessCommand(new DeletePost(id));
            return RedirectToAction("Posts", "Dashboard");
        }
    }
}
