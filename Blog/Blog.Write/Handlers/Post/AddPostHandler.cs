using Blog.Bus;
using Blog.Context;
using Blog.Write.Commands.Post;
using Blog.Write.Events.Post;

using PostEntity = Blog.Context.Models.Post;

namespace Blog.Write.Handlers.Post
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
            var post = new PostEntity
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
