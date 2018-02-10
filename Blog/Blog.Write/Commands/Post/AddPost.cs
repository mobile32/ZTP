using System;
using System.ComponentModel;
using Blog.Bus;

namespace Blog.Command.Commands.Post
{
    public class AddPost: ICommand
    {
        public string Title { get; }
        public string Description { get; }
        public string Content { get; }
        public DateTime PostDate { get; }
        public int CategoryId { get; }
        public int UserId { get; }

        public AddPost(int categoryId, string title, string description, string content, DateTime postDate, int userId)
        {
            UserId = userId;
            CategoryId = categoryId;
            Description = description;
            Title = title;
            Content = content;
            PostDate = postDate;
        }
    }
}
