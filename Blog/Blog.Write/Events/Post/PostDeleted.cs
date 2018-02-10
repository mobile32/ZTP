using System;
using System.Collections.Generic;
using System.Text;
using Blog.Bus;

namespace Blog.Command.Events.Post
{
    public class PostDeleted : IEvent
    {
        public int Id { get; }

        public PostDeleted(int id)
        {
            Id = id;
        }
    }
}
