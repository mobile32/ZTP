using System;
using System.Collections.Generic;
using System.Text;
using Blog.Bus;
using Blog.Command.Commands.Post;
using Blog.Command.Events.Post;
using Blog.DAL;

namespace Blog.Command.Handlers.Post
{
    class DeleteCommentHandler: IHandler<DeleteComment>
    {
        private readonly IEventBus _eventBus;
        private readonly BlogContext _db;

        public DeleteCommentHandler(IEventBus eventBus, BlogContext db)
        {
            _eventBus = eventBus;
            _db = db;
        }

        public void ExecuteCommand(DeleteComment command)
        {
            var comment = _db.Comments.Find(command.Id);
            if (comment != null)
            {
                _db.Comments.Remove(comment);
                _db.SaveChanges();
                _eventBus.PublishEvent(new DeletedComment(command.Id));
            }
        }
    }
}
