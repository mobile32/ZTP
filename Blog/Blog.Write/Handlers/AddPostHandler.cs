using Blog.Bus;
using Blog.Write.Commands;
using Blog.Write.DAL;
using Blog.Write.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Write.Handlers
{
    class AddPostHandler : IHandler<AddPost>
    {
        private readonly IEventBus _eventBus;
        private readonly BlogContext _db;

        public AddPostHandler(IEventBus eventBus, BlogContext db)
        {
            _eventBus = eventBus;
            _db = db;
        }

        public void ExecuteCommand(AddPost cmd)
        {
            var post = new DAL.Models.Post
            {
                Content = cmd.Content,
                PostDate = cmd.PostDate,
                Title = cmd.Title,
                CategoryId = cmd.CategoryId
            };
            _db.Posts.Add(post);
            _db.SaveChanges();

            _eventBus.PublishEvent(new AddedPost(post.Id, cmd.Title, cmd.Title, cmd.PostDate));
        }
    }
}
