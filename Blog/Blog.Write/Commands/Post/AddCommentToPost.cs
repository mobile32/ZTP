using Blog.Bus;

namespace Blog.Command.Commands.Post
{
    public class AddCommentToPost: ICommand
    {
        public int Id { get; }
        public string Author { get; }
        public string Comment { get; }

        public AddCommentToPost(int id, string author, string comment)
        {
            Id = id;
            Author = author;
            Comment = comment;
        }
    }
}
