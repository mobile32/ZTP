using Blog.Bus;
using Blog.Command.Events.Post;

namespace Blog.Command.EventHandlers.Post
{
    class EditedPostHandler : IEventHandler<EditedPost>
    {
        public void HandleEvent(EditedPost evt)
        {
        }
    }
}
