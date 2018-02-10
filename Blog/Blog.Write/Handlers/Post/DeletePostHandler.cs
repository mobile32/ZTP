using System;
using System.Collections.Generic;
using System.Text;
using Blog.Bus;
using Blog.Command.Commands.Post;
using Blog.Command.Events.Post;
using Blog.DAL;

namespace Blog.Command.Handlers.Post
{
    class DeletePostHandler : IHandler<DeletePost>
    {
        private readonly IEventBus _eventBus;
        private readonly BlogContext _db;

        public DeletePostHandler(IEventBus eventBus, BlogContext db)
        {
            _eventBus = eventBus;
            _db = db;
        }
        public void ExecuteCommand(DeletePost command)
        {
            var post = _db.Posts.Find(command.Id);
            if (post != null)
            {
                _db.Posts.Remove(post);
                _db.SaveChanges();
                _eventBus.PublishEvent(new PostDeleted(command.Id));
            }
        }
    }
}
