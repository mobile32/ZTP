﻿using Blog.Bus;
using System;

namespace Blog.Write.Events
{
    public class AddedPost: IEvent
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime PostDate { get; private set; }

        public AddedPost(int id, string title, string content, DateTime postDate)
        {
            Id = id;
            Title = title;
            Content = content;
            PostDate = postDate;
        }
    }
}
