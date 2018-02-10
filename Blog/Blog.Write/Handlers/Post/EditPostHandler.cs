using System.Collections.Generic;
using Blog.Bus;
using Blog.Command.Commands.Post;
using Blog.Command.Events.Post;
using Blog.DAL;

namespace Blog.Command.Handlers.Post
{
    class EditPostHandler : IHandler<EditPost>
    {
        private readonly IEventBus _eventBus;
        private readonly BlogContext _db;

        public EditPostHandler(IEventBus eventBus, BlogContext db)
        {
            _eventBus = eventBus;
            _db = db;
        }
        public void ExecuteCommand(EditPost command)
        {
            var post = _db.Posts.Find(command.Id);
            if (post != null)
            {
                if (post.CategoryId != command.CategoryId)
                {
                    _eventBus.PublishEvent(new PostCategoryIdChanged(post.Id,post.CategoryId,command.CategoryId));
                    post.CategoryId = command.CategoryId;
                }
                if (post.Title != command.Title)
                {
                    _eventBus.PublishEvent(new PostTitleChanged(post.Id, post.Title, command.Title));
                    post.Title = command.Title;
                }
                if (post.Description != command.Description)
                {
                    _eventBus.PublishEvent(new PostDescriptionChanged(post.Id, post.Description, command.Description));
                    post.Description = command.Description;
                }
                if (post.Content != command.Content)
                {
                    _eventBus.PublishEvent(new PostContentChanged(post.Id, post.Content, command.Content));
                    post.Content = command.Content;
                }
                _db.SaveChanges();
            }
        }
    }
}
