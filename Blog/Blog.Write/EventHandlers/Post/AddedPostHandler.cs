using Blog.Bus;
using Blog.Write.Events.Post;

namespace Blog.Write.EventHandlers.Post
{
    class AddedPostHandler : IEventHandler<AddedPost>
    {
        public void HandleEvent(AddedPost evt)
        {
            //1
        }
    }
}
