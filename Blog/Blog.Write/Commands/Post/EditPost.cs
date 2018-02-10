using Blog.Bus;

namespace Blog.Command.Commands.Post
{
    public class EditPost : ICommand
    {
        public int Id { get; }
        public int CategoryId { get; }
        public string Title { get; }
        public string Description { get; }
        public string Content { get; }

        public EditPost(int id, int categoryId, string title, string description, string content)
        {
            Id = id;
            CategoryId = categoryId;
            Description = description;
            Title = title;
            Content = content;
        }
    }
}
