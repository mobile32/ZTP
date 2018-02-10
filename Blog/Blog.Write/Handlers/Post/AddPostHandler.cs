using Blog.Bus;
using Blog.Command.Commands.Post;
using Blog.Command.Events.Post;
using Blog.Context;
using PostEntity = Blog.Context.Models.Post;

namespace Blog.Command.Handlers.Post
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
