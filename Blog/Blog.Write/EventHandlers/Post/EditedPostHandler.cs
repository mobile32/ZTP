using Blog.Bus;
using Blog.Command.Events.Post;

namespace Blog.Command.EventHandlers.Post
{
    class EditedPostHandler : IEventHandler<PostContentChanged>
    {
        public void HandleEvent(PostContentChanged evt)
        {
            //costam
        }
    }
}
