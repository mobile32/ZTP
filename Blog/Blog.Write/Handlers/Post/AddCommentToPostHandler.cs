using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Bus;
using Blog.Command.Commands.Post;
using Blog.Command.Events.Post;
using Blog.DAL;
using Blog.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Command.Handlers.Post
{
    class AddCommentToPostHandler: IHandler<AddCommentToPost>
    {
        private readonly IEventBus _eventBus;
        private readonly BlogContext _db;

        public AddCommentToPostHandler(IEventBus eventBus, BlogContext db)
        {
            _eventBus = eventBus;
            _db = db;
        }
        public void ExecuteCommand(AddCommentToPost command)
        {
            var post = _db.Posts.Include(x=> x.Comments).FirstOrDefault(x=> x.Id == command.Id);
            if (post != null)
            {
                post.Comments.Add(new Comment
                {
                    Author = command.Author,
                    CommentDate =  DateTime.Now,
                    Content = command.Comment,
                    PostId = command.Id
                });
                _db.SaveChanges();
                _eventBus.PublishEvent(new AddedCommentToPost(command.Id,command.Author,command.Comment));
            }
        }
    }
}
