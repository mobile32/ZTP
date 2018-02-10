using Blog.Bus;
using Blog.Command.Commands.Post;

namespace Blog.Command.Handlers.Post
{
    class EditPostHandler : IHandler<EditPost>
    {
        public void ExecuteCommand(EditPost command)
        {
        }
    }
}
