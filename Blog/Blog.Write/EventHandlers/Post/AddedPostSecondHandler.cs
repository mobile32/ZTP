using Blog.Bus;
using Blog.Command.Events.Post;

namespace Blog.Command.EventHandlers.Post
{
    class AddedPostSecondHandler : IEventHandler<AddedPost>
    {
        public void HandleEvent(AddedPost evt)
        {
            //2
        }
    }
}
