using Blog.Bus;
using Blog.Command.Events.Post;

namespace Blog.Command.EventHandlers.Post
{
    class AddedPostHandler : IEventHandler<AddedPost>
    {
        public void HandleEvent(AddedPost evt)
        {
            //1
        }
    }
}
