using Blog.Bus;
using Blog.Write.Events.Post;

namespace Blog.Write.EventHandlers.Post
{
    class AddedPostSecondHandler : IEventHandler<AddedPost>
    {
        public void HandleEvent(AddedPost evt)
        {
            //2
        }
    }
}
