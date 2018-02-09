using Blog.Bus;
using Blog.Write.Events.Post;

namespace Blog.Write.EventHandlers.Post
{
    class EditedPostHandler : IEventHandler<EditedPost>
    {
        public void HandleEvent(EditedPost evt)
        {
        }
    }
}
