using System;
using Blog.Bus;

namespace Blog.Command.Events.Post
{
    public class AddedPost: IEvent
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string Content { get; }
        public DateTime PostDate { get; }

        public AddedPost(int id, string title, string description, string content, DateTime postDate)
        {
            Description = description;
            Id = id;
            Title = title;
            Content = content;
            PostDate = postDate;
        }
    }
}
