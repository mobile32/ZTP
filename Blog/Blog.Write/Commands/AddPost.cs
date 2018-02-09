using Blog.Bus;
using System;

namespace Blog.Write.Commands
{
    public class AddPost: ICommand
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime PostDate { get; private set; }
        public int CategoryId { get; private set; }

        public AddPost(int categoryId, string title, string content, DateTime postDate)
        {
            CategoryId = categoryId;
            Title = title;
            Content = content;
            PostDate = postDate;
        }
    }
}
