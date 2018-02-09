using Blog.Bus;
using Blog.Write.Commands.Post;

namespace Blog.Write.Handlers.Post
{
    class EditPostHandler : IHandler<EditPost>
    {
        public void ExecuteCommand(EditPost command)
        {
        }
    }
}
